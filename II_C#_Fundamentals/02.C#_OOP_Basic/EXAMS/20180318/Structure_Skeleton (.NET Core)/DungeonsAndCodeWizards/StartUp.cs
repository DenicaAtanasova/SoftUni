namespace DungeonsAndCodeWizards
{
    using DungeonsAndCodeWizards.Core;
    using DungeonsAndCodeWizards.Core.IO;

    public class StartUp
	{
		// DO NOT rename this file's namespace or class name.
		// However, you ARE allowed to use your own namespaces (or no namespaces at all if you prefer) in other classes.
		public static void Main(string[] args)
		{
            var reader = new Reader();
            var writer = new Writer();

            Engine engine = new Engine(reader, writer);
            engine.Run();
        }
	}
}