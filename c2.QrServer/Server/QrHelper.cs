using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXing;
using ZXing.Common;
using ZXing.QrCode;

namespace c2.QrServer
{
    public class QrHelper
    {

        /// <summary>
        /// 生成Bitmap
        /// </summary>
        /// <param name="content"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static Bitmap ToBitmap(string content, int width = 400, int height = 400)
        {
            var hints = new Dictionary<EncodeHintType, object> {{EncodeHintType.CHARACTER_SET, "UTF-8"}};

            var matrix = new MultiFormatWriter().encode(content, BarcodeFormat.QR_CODE, width, height, hints);

            matrix = CutWhiteBorder(matrix);
            var barcodeWriter = new BarcodeWriter
            {
                Format = BarcodeFormat.QR_CODE,

                Options = new QrCodeEncodingOptions
                {
                    Margin = 0,
                    Height = height,
                    Width = width
                }
            };

            barcodeWriter.Options.Width = matrix.Width;
            barcodeWriter.Options.Height = matrix.Height;
            var codeImage = barcodeWriter.Write(matrix);
            return codeImage;
        }


        private static BitMatrix CutWhiteBorder(BitMatrix matrix)
        {
            int[] rec = matrix.getEnclosingRectangle();
            int resWidth = rec[2] + 1;
            int resHeight = rec[3] + 1;
            BitMatrix resMatrix = new BitMatrix(resWidth + 1, resHeight + 1);
            resMatrix.clear();
            for (int i = 0; i < resWidth; i++)
            {
                for (int j = 0; j < resHeight; j++)
                {
                    if (matrix[i + rec[0], j + rec[1]])
                    {
                        resMatrix.flip(i + 1, j + 1);
                    }
                }
            }
            return resMatrix;
        }

        /// <summary>
        /// 图片转码 
        /// JPEG 格式
        /// </summary>
        /// <param name="bitmap"></param>
        /// <returns></returns>
        public static byte[] BitmapToBytes(Bitmap bitmap)
        {
            MemoryStream ms = null;
            try
            {
                ms = new MemoryStream();
                bitmap.Save(ms, ImageFormat.Jpeg);
                byte[] byteImage = ms.ToArray();
                return byteImage;
            }
            finally
            {
                ms.Close();
            }
        }
    }
}
