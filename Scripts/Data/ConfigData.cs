public class ConfigData {

	/*diff difficulty diff mine nums*/
	public const int MINE_NUM_A = 15;
	public const int MINE_NUM_B = 30;
	public const int MINE_NUM_C = 42;
	/********************************/

	/*diff screen aspect ratio has diff grid layout*/
	public const int ITEMS_RON_NUM_177 = 14;
	public const int ITEMS_ROW_NUM_150 = 13;
	public const int ITEMS_ROW_NUM_133 = 12;

	public const int ITEMS_COL_NUM_177 = 10;
	public const int ITEMS_COL_NUM_150 = 11;
	public const int ITEMS_COL_NUM_133 = 12;
	/***********************************************/


	public static int GetCurMineNum(DifficultyType diffType)
	{
		int mineNum = 0;
		switch (diffType) {
		case DifficultyType.Easy:
			mineNum = ConfigData.MINE_NUM_A;
			break;
		case DifficultyType.Normal:
			mineNum = ConfigData.MINE_NUM_B;
			break;
		case DifficultyType.Hard:
			mineNum = ConfigData.MINE_NUM_C;
			break;
		}
		return mineNum;
	}

}

