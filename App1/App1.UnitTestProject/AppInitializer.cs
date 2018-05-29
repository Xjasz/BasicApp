using Xamarin.UITest;

namespace App1.UnitTestProject
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            if (platform == Platform.Android)
            {
                var Emulator = "169.254.190.187:5555";

                return ConfigureApp
                    .Android
                    .ApkFile(@"C:\Users\nicholascodalata\source\repos\basicapp\App1\App1.Android\bin\Debug\App1.UITesting.apk")
                    .StartApp();
            }
            return ConfigureApp.iOS.StartApp();
        }
    }
}
