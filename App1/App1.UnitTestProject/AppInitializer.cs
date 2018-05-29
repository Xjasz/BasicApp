using Xamarin.UITest;

namespace App1.UnitTestProject
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            if (platform == Platform.Android)
            {
                var Emulator = "emulator-5554";
                var Device = "988ad9453449324b51";

                return ConfigureApp
                    .Android
                    .DeviceSerial(Emulator)
                    .ApkFile(@"C:\Users\nicholascodalata\source\repos\basicapp\App1\App1.Android\bin\Debug\App1.UITesting.apk")
                    .StartApp();
            }
            return ConfigureApp.iOS.StartApp();
        }
    }
}
