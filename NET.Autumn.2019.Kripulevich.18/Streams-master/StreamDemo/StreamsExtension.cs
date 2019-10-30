using System;
using System.IO;
using System.Text;

namespace StreamDemo
{
    // C# 6.0 in a Nutshell. Joseph Albahari, Ben Albahari. O'Reilly Media. 2015
    // Chapter 15: Streams and I/O
    // Chapter 6: Framework Fundamentals - Text Encodings and Unicode
    // https://docs.microsoft.com/en-us/dotnet/api/system.text.encoding?view=netcore-3.0
    // https://docs.microsoft.com/en-us/dotnet/api/system.io?view=netcore-3.0

    public static class StreamsExtension
    {
        #region Public members

        #region TODO: Implement by byte copy logic using class FileStream as a backing store stream .

        public static int ByByteCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);

            int count = 0;
            using (FileStream fileStreamSource = new FileStream(sourcePath, FileMode.Open))
            using (FileStream fileStreamDest = new FileStream(destinationPath, FileMode.Create))
            {
                int b;
                while ((b = fileStreamSource.ReadByte()) > 0)
                {
                    fileStreamDest.WriteByte((byte)b);
                    count++;
                }
            }
            return count;
        }

        #endregion

        #region TODO: Implement by byte copy logic using class MemoryStream as a backing store stream.

        public static int InMemoryByByteCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);

            var UTF8 = new UTF8Encoding(true);
            int count = 0;
            string @string;
            using (StreamReader reader = new StreamReader(sourcePath, UTF8))
            {
                @string = reader.ReadToEnd();
            }
            var byteBuffer = UTF8.GetBytes(@string);
            MemoryStream memoryStream = new MemoryStream(byteBuffer);
            var arrayBuffer = memoryStream.ToArray();
            var charBuffer = UTF8.GetString(arrayBuffer);
            using (StreamWriter streamWriter = new StreamWriter(destinationPath, false, UTF8))
            {
                foreach (var item in charBuffer)
                {
                    streamWriter.Write(item);
                    count++;
                }
            }
            return count;
        }

        #endregion

        #region TODO: Implement by block copy logic using FileStream buffer.
        
        public static int ByBlockCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);

            int count = 0;
            int bufferSize = 1024;
            using (FileStream sourceFile = new FileStream(sourcePath, FileMode.Open, FileAccess.Read))
            using (FileStream destinationFile = new FileStream(destinationPath, FileMode.Create, FileAccess.Write))
            {
                byte[] buffer = new byte[bufferSize];
                int length = 0;
                while ((length = sourceFile.Read(buffer, 0, bufferSize)) > 0)
                {
                    destinationFile.Write(buffer, 0, length);
                    count += length;
                }
            }
            return count;
        }

        #endregion

        #region TODO: Implement by block copy logic using MemoryStream.
        
        public static int InMemoryByBlockCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);

            var UTF8 = new UTF8Encoding(true);
            int bufferSize = 1024;
            char[] charBuffer = new char[bufferSize];
            int length = 0;
            int count = 0;
            using (StreamReader sourceFile = new StreamReader(sourcePath, UTF8))
            using (StreamWriter destinationWriter = new StreamWriter(destinationPath, false, UTF8))
            {
                while ((length = sourceFile.ReadBlock(charBuffer, 0, bufferSize)) > 0)
                {
                    byte[] byteBuffer = new byte[length];
                    byteBuffer = UTF8.GetBytes(charBuffer, 0, length);
                    MemoryStream memoryStream = new MemoryStream(byteBuffer);
                    byte[] newByteBuffer = memoryStream.ToArray();
                    var newCharBuffer = new char[length]; 
                    UTF8.GetChars(newByteBuffer, newCharBuffer);
                    foreach (var c in newCharBuffer)
                    {
                        destinationWriter.Write(c);
                        count++;
                    }
                }
            }
            return count;
        }

        #endregion

        #region TODO: Implement by block copy logic using class-decorator BufferedStream.

        public static int BufferedCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);

            int bufferSize = 1024;
            int length = 0;
            byte[] buffer = new byte[bufferSize];
            int count = 0;
            using (var sourceFile = new FileStream(sourcePath, FileMode.Open))
            using (var destinationFile = new FileStream(destinationPath, FileMode.Create))
            using (var sourceBufferFile = new BufferedStream(sourceFile, bufferSize))
            using (var destinationBufferFile = new BufferedStream(destinationFile, bufferSize))
            {
                while ((length = sourceFile.Read(buffer, 0, bufferSize)) > 0)
                {
                    destinationFile.Write(buffer, 0, length);
                    count += length;
                }
            }
            return count;
        }

        #endregion

        #region TODO: Implement by line copy logic using FileStream and classes text-adapters StreamReader/StreamWriter

        public static int ByLineCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);
            var UTF8 = new UTF8Encoding(true);
            int count = 0;
            string buffer;
            using (var sourceFile = new FileStream(sourcePath, FileMode.Open, FileAccess.Read))
            using (var destinationFile = new FileStream(destinationPath, FileMode.Create, FileAccess.Write))
            using (var sourceReader = new StreamReader(sourceFile, UTF8))
            using (var destinationWriter = new StreamWriter(destinationFile, UTF8))
            {
                while ((buffer = sourceReader.ReadLine()) != null)
                {
                    destinationWriter.WriteLine(buffer);
                    count++;
                }
            }
            return count;
        }

        #endregion

        #endregion

        #region Private members

        #region TODO: Implement validation logic

        private static void InputValidation(string sourcePath, string destinationPath)
        {
            if (sourcePath is null)
            {
                throw new ArgumentNullException(nameof(sourcePath));
            }

            if (destinationPath == null)
            {
                throw new ArgumentNullException(nameof(destinationPath));
            }

            if (!File.Exists(sourcePath))
            {
                throw new FileNotFoundException(
                    $"File '{sourcePath}' not found. Parameter name: {nameof(sourcePath)}.");
            }

//            if (!File.Exists(destinationPath))
//            {
//                try
//                {
//                    File.Create(destinationPath);
//                }
//                catch
//                {
//                    throw new FileNotFoundException(
//                        $"File '{destinationPath}' not found and can not be created. Parameter name: {nameof(destinationPath)}.");
//                }
//            }

//            if (new FileInfo(destinationPath).IsReadOnly)
//            {
//                throw new FieldAccessException(
//                    $"File '{destinationPath}' is readonly. Parameter name: {nameof(destinationPath)}.");
//            }
        }

        #endregion

        #endregion
    }
}