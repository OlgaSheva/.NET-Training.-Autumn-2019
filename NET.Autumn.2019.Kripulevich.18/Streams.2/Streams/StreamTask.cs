using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using OfficeOpenXml;

namespace Streams
{
	public static class StreamTask
	{
		/// <summary>
		/// Parses Resources\Planets.xlsx file and returns the planet data: 
		///   Jupiter     69911.00
		///   Saturn      58232.00
		///   Uranus      25362.00
		///    ...
		/// See Resources\Planets.xlsx for details
		/// </summary>
		/// <param name="xlsxFileName">Source file name.</param>
		/// <returns>Sequence of PlanetInfo</returns>
		public static IEnumerable<PlanetInfo> ReadPlanetInfoFromXlsx(string xlsxFileName)
		{
			if (xlsxFileName == null)
            {
                throw new ArgumentNullException(nameof(xlsxFileName));
            }

            using (ExcelPackage xlPackage = new ExcelPackage(new FileInfo(xlsxFileName)))
            {
                var sheet1 = xlPackage.Workbook.Worksheets.First();
                var totalRows = sheet1.Dimension.End.Row;
                var totalColumns = sheet1.Dimension.End.Column;
                
                for (int rowNum = 2; rowNum <= totalRows; rowNum++)
                {
                    var row = sheet1.Cells[rowNum, 1, rowNum, totalColumns].Select(c => c.Value == null ? string.Empty : c.Value.ToString());
                    row = row.Where(x => x != string.Empty);
                    if (!double.TryParse(row.Last(), out double radious))
                    {
                        throw new ArgumentException("Invalid radious.", nameof(xlsxFileName));
                    }

                    yield return new PlanetInfo() { Name = row.First(), MeanRadius = radious };
                }
            }
        }

		/// <summary>
		/// Calculates hash of stream using specified algorithm.
		/// </summary>
		/// <param name="stream">Source stream</param>
		/// <param name="hashAlgorithmName">
		///     Hash algorithm ("MD5","SHA1","SHA256" and other supported by .NET).
		/// </param>
		/// <returns></returns>
		public static string CalculateHash(this Stream stream, string hashAlgorithmName)
		{
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            if (hashAlgorithmName == null)
            {
                throw new ArgumentNullException(nameof(hashAlgorithmName));
            }

            if (string.IsNullOrWhiteSpace(hashAlgorithmName))
            {
                throw new ArgumentException("Hash algorithm name canbot be empty.", nameof(hashAlgorithmName));
            }

            var hashAlgorithm = HashAlgorithm.Create(hashAlgorithmName)
                ?? throw new ArgumentException("Invalid algorithm.", nameof(hashAlgorithmName));
            byte[] hash = hashAlgorithm.ComputeHash(stream);
            return string.Join(
                string.Empty,
                hash.Select(x => x.ToString("X2")));
        }

        /// <summary>
        /// Returns decompressed stream from file. 
        /// </summary>
        /// <param name="fileName">Source file.</param>
        /// <param name="method">Method used for compression (none, deflate, gzip).</param>
        /// <returns>output stream</returns>
        public static Stream DecompressStream(string fileName, DecompressionMethods method)
		{
            if (fileName == null)
            {
                throw new ArgumentNullException(nameof(fileName));
            }

            if (string.IsNullOrWhiteSpace(fileName))
            {
                throw new ArgumentException($"The {nameof(fileName)} cannot be empty.", nameof(fileName));
            }

            FileStream fileStream = new FileStream(fileName, FileMode.Open);

            switch (method)
            {
                case DecompressionMethods.Deflate:
                    return new DeflateStream(fileStream, CompressionMode.Decompress);
                case DecompressionMethods.GZip:
                    return new GZipStream(fileStream, CompressionMode.Decompress);
                default:
                    return fileStream;
            }
        }

		/// <summary>
		/// Reads file content encoded with non Unicode encoding
		/// </summary>
		/// <param name="fileName">Source file name</param>
		/// <param name="encoding">Encoding name</param>
		/// <returns>Unicoded file content</returns>
		public static string ReadEncodedText(string fileName, string encoding)
		{
            if (fileName == null)
            {
                throw new ArgumentNullException(nameof(fileName));
            }

            if (encoding == null)
            {
                throw new ArgumentNullException(nameof(encoding));
            }

            if (string.IsNullOrWhiteSpace(fileName))
            {
                throw new ArgumentException($"The {nameof(fileName)} cannot be empty.", nameof(fileName));
            }

            if (string.IsNullOrWhiteSpace(encoding))
            {
                throw new ArgumentException($"The {nameof(encoding)} cannot be empty.", nameof(encoding));
            }

            using (StreamReader reader = new StreamReader(fileName, Encoding.GetEncoding(encoding)))
            {
                return reader.ReadToEnd();
            }
        }
	}
}