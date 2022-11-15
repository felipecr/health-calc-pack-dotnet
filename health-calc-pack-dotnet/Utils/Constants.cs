namespace health_calc_pack_dotnet.Utils
{
    public static class Constants
    {
        #region SharedValues

        public const double MIN_WEIGHT = 35;
        public const double GRAMS_OF_PROTEIN = 2;
        public const double GRAMS_OF_FAT = 1;

        #endregion

        #region BulkingValues

        public const double GRAMS_OF_FAT_TO_BULKING = 2;        
        public const double GRAMS_OF_CARBOHYDRATE_TO_BULKING = 4;
        public const double GRAMS_OF_CARBOHYDRATE_TO_BULKING_FOR_MORE_ACTIVE_PEOPLE = 7;
        public const double MALE_MULTIPLIER_TO_BULKING = 1;
        public const double FEMALE_MULTIPLIER_TO_BULKING = 0.8;

        #endregion

        #region CuttingValues

        public const double GRAMS_OF_CARBOHYDRATE_TO_CUTTING = 2;

        #endregion

        #region MaintenanceValues

        public const double GRAMS_OF_CARBOHYDRATE_TO_MAINTENANCE = 5;

        #endregion
    }
}
