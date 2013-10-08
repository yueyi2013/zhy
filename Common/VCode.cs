using System;
using System.Drawing;
using System.Text;

namespace ZHY.Common
{
   public class VCode
    {
       public static string[] Vcode = new string[] 
        {
            //0
            "11111110000000000000000111111111110000000000000111111111111100000000000111100000001111000000000011000000000001100000000001100000000000110000000000110000000000011000000000011110000000111100000000000111111111111100000000000001111111111100000000000000001111111",
            //1
            "1100000000001100000000000110000000000110000000000011000000000011000000000011111111111111100000000001111111111111110000000000111111111111111000000000000000000000001100000000000000000000000110000000000000000000000011",
            //2
            "11000000000111000000000011000000000111100000000001100000000111110000000000110000000111011000000000011000000111001100000000001100000111000110000000000111000111000011000000000001111111000001100000000000111111000000110000000000001111000000011",    
            //3
            "11000000000110000000000011000011000001100000000001100001100000110000000000110000110000011000000000011000011000001100000000001110011110001110000000000111111111111110000000000001111100111111000000000000011100000111",
            //4
            "11100000000000000000000011110000000000000000000011011000000000000000000011001100000000000000000111000110000000000000000111000011000000000000000110000001100000000000000111111111111111000000000011111111111111100000000001111111111111110000000000000000000110000000000000000000000011",
            //5
            "11111110000011000000000001111111000000110000000000110001100000011000000000011000110000001100000000001100011100000110000000000110000111000111000000000011000011111111000000000001100000111111100000000000110000001111",
            //6
            "111111100000000000000001111111111100000000000001111111111111000000000000111001100001110000000000111000100000011000000000011000110000001100000000001100011000000110000000000110001110000111000000000011000111111111000000000000110001111111100000000000000000011111",
            //7
            "110000000000000000000000011000000000001100000000001100000000011110000000000110000000111111000000000011000001111100000000000001100011111000000000000000110011110000000000000000011111000000000000000000001111000000000000000000000111",
            //8
            "11110000000000000011100011111100000000000011111111111110000000000011111111100011100000000001100011100000110000000000110001110000011000000000011000011100001100000000001111111111001110000000000011111001111110000000000000111000111111000000000000000000001111",
            //9
            "111100000000000000000001111111100011000000000000111111111000110000000000111000011100011000000000011000000110001100000000001100000011000110000000000110000001100111000000000011100001100111000000000000111111111111100000000000001111111111100000000000000001111111"
        };

        /// <summary>
        /// 去掉其他颜色噪点，前期图片处理
        /// </summary>
        /// <param name="bmp"></param>
        /// <param name="crl"></param>
        /// <returns></returns>
       public static Bitmap ClearOtherColor(Bitmap bmp, int crl)
        {
            int width = bmp.Width;
            int height = bmp.Height;
            Bitmap tmpbmp = new Bitmap(width - 1, height);
            for (int i = 2; i < width + 1; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (i < width)
                    {
                        Color currcolor = bmp.GetPixel(i, j);
                        if (currcolor.R > crl || currcolor.G > crl || currcolor.B > crl || currcolor.R != currcolor.B || currcolor.R != currcolor.G || currcolor.G != currcolor.B)
                        {
                            tmpbmp.SetPixel(i - 2, j, Color.White);
                        }
                        else
                        {
                            tmpbmp.SetPixel(i - 2, j, Color.Black);
                        }
                    }
                    else if (i == width)
                    {
                        tmpbmp.SetPixel(i - 2, j, Color.White);
                    }
                }
            }
            return tmpbmp;
        }

        /// <summary>
        /// 平均分割图片
        /// </summary>
        /// <param name="RowNum">水平上分割数</param>
        /// <param name="ColNum">垂直上分割数</param>
        /// <returns>分割好的图片数组</returns>
       public static Bitmap[] GetSplitPics(Bitmap bmpobj, int RowNum, int ColNum)
        {
            if (RowNum == 0 || ColNum == 0)
                return null;
            int singW = bmpobj.Width / RowNum;
            int singH = bmpobj.Height / ColNum;
            Bitmap[] PicArray = new Bitmap[RowNum * ColNum];
            Rectangle cloneRect;
            for (int i = 0; i < ColNum; i++)      //找有效区
            {
                for (int j = 0; j < RowNum; j++)
                {
                    cloneRect = new Rectangle(j * singW, i * singH, singW, singH);
                    PicArray[i * RowNum + j] = bmpobj.Clone(cloneRect, bmpobj.PixelFormat);//复制小块图
                }
            }
            return PicArray;
        }

        /// <summary>
        /// 匹配
        /// </summary>
        /// <param name="data"></param>
        /// <param name="p"></param>
        /// <returns></returns>
       public static string MatchCode(string data)
        {
            int result = 0;
            double currp = 0.0;
            for (int i = 0; i < 10; i++)
            {
                if (Vcode[i].IndexOf(data) != -1 || data.IndexOf(Vcode[i]) != -1) return i.ToString();
                int countlen = Vcode[i].Length;
                if (data.Length < countlen) countlen = data.Length;
                int matchescount = 0;
                for (int j = 0; j < countlen; j++)
                {
                    if (data[j] == Vcode[i][j])
                    {
                        matchescount++;
                    }
                }
                double pcount = (double)matchescount / (double)countlen;
                if (pcount > currp)
                {
                    currp = pcount;
                    result = i;
                }
            }
            return result.ToString();
        }

        /// <summary>
        /// 获取图片的验证码字符串
        /// </summary>
        /// <param name="bmp">源图片</param>
        /// <param name="CodeLen">验证码的长度</param>
        /// <returns></returns>
        public static string GetVCode(Bitmap bmp,int CodeLen)
        {
            bmp = ClearOtherColor(bmp, 20);
            Bitmap[] bmps = GetSplitPics(bmp, CodeLen, 1);
            String[] data = new String[CodeLen];
            for (int i = 0; i < bmps.Length; i++)
            {
                StringBuilder databulider = new StringBuilder();
                for (int x = 0; x < bmps[i].Width; x++)
                {
                    for (int y = 0; y < bmps[i].Height; y++)
                    {
                        Color currcolor = bmps[i].GetPixel(x, y);
                        if (currcolor.R == 255)
                        {
                            databulider.Append("0");
                        }
                        else
                        {
                            databulider.Append("1");
                        }
                    }
                }
                data[i] = databulider.ToString().TrimStart('0').TrimEnd('0');//去掉特征码中的头部0 和尾部0
            }
            string Value = "";
            for (int i = 0; i < data.Length; i++)
            {
                Value += MatchCode(data[i]);
            }
            return Value;
        }

    }
}
