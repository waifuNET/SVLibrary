using System.IO;

namespace SVLibrary.SVimg
{
    class SVimg
    {
        public static byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, imageIn.RawFormat);
                return ms.ToArray();
            }
        }
        public static System.Drawing.Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            System.Drawing.Image returnImage = System.Drawing.Image.FromStream(ms);
            return returnImage;
        }

        public static void ImgInByte(string patch)
        {
            byte[] bytes = ImageToByteArray(System.Drawing.Image.FromFile(patch));
            using (FileStream fileStream = new FileStream(patch, FileMode.Create))
            {
                for (int i = 0; i < bytes.Length; i++)
                {
                    fileStream.WriteByte(bytes[i]);
                }

                fileStream.Close();
                fileStream.Dispose();
            }
        }
        //ImgInByte();
        //byte[] craft = File.ReadAllBytes(fileName);
        //byteArrayToImage(craft).Save("Test.jpg", ImageFormat.Jpeg);
        //Process.Start("Test.jpg");
    }
}
