namespace order
{
    public static class DatabaseMigration
    {
        public static void MigrateDatabase()
        {
            MigrateOrders();
            MigrateSubOrders();
        }


        private static void MigrateOrders()
        {

            string Orderpath = "order.json";

            if (!File.Exists(Orderpath))
            {
                // Create a file to write to.

                File.WriteAllText(Orderpath, "[]");
            }
        }


        private static void MigrateSubOrders()
        {
            string subOrederPath = "suborder.json";

            if (!File.Exists(subOrederPath))
            {
                // Create a file to write to.

                File.WriteAllText(subOrederPath, "[]");

            }
        }
    }
}
