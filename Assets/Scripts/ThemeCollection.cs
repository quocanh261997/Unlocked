using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;


public class ThemeCollection : MonoBehaviour {
	public Sprite[] dots;
	public Sprite[] images;

	public static List<Theme> themes = null;
	public static List<Theme> getThemes(){
		if (themes == null) {
			themes = new List<Theme> ();
			themes.Add (new Theme ("4ef106", "fc0c94", "1b5ea8", "004a80", "dot_default", "icon_default",1));
			themes.Add (new Theme ("f33a3d", "ffcc5c", "770519", "520411", "dot_bulleye", "icon_bulleye",1));
			themes.Add (new Theme ("ea0888", "45e002", "0175bb", "064c76", "dot_hexagon", "icon_hexagon",1));
			themes.Add (new Theme ("feda7e", "00ff00", "440e62", "230434", "dot_smiley", "icon_smiley",1));
			themes.Add (new Theme ("00fff6", "ea0888", "015366", "003541", "dot_pixel", "icon_pixel",1));
			themes.Add (new Theme ("fff000", "ff7200", "015366", "003541", "dot_star", "icon_star",1));
			themes.Add (new Theme ("aeff00", "00fff6", "01459e", "022553", "dot_button", "icon_button",1));
			themes.Add (new Theme ("efeeee", "0e0b08", "5d330c", "301b07", "dot_skull", "icon_skull",1));
			themes.Add (new Theme ("ff1216", "00ff8a", "191919", "000000", "dot_billiardball", "icon_billiardball",1));
			themes.Add (new Theme ("ff9600", "00ff60", "191919", "000000", "dot_shuriken", "icon_shuriken",2));
			themes.Add (new Theme ("f8970e", "3b88dd", "3e3987", "28255b", "dot_gear", "icon_gear",1));
			themes.Add (new Theme ("ffd800", "00ff8a", "8f0531", "50031c", "dot_radiation", "icon_radiation",1));
			themes.Add (new Theme ("b2f72c", "fb2d31", "440e62", "230434", "dot_watermelon", "icon_watermelon",1));
			themes.Add (new Theme ("ff30ff", "0289db", "5a0602", "300301", "dot_virus", "icon_virus",1));
			themes.Add (new Theme ("9b02ed", "ffd800", "4c061c", "28000d", "dot_flower", "icon_flower",1));
			themes.Add (new Theme ("ffff00", "ea0888", "5a0602", "370200", "dot_sun", "icon_sun",1));
			themes.Add (new Theme ("4ef106", "ffd800", "095c34", "073f24", "dot_cloverleaf", "icon_cloverleaf",1));
			themes.Add (new Theme ("00fff6", "ff7200", "015366", "003541", "dot_controller", "icon_controller",1));
			themes.Add (new Theme ("dadada", "ff9600", "512801", "2e1700", "dot_windpump", "icon_windpump",1));
			themes.Add (new Theme ("191919", "f8de73", "af0336", "700021", "dot_aim", "icon_aim",1));
			themes.Add (new Theme ("ff7f00", "ffff00", "0550b3", "033476", "dot_basketball", "icon_basketball",1));
			themes.Add (new Theme ("ff0000", "00fff6", "015e01", "013101", "dot_heart", "icon_heart",1));
			themes.Add (new Theme ("a92726", "ffcc5c", "00a6b6", "037a86", "dot_justice", "icon_justice",1));
			themes.Add (new Theme ("f5193f", "00fff6", "710427", "380415", "dot_bomb", "icon_bomb",1));
			themes.Add (new Theme ("fe8acc", "4ef106", "8f0531", "4c061c", "dot_rose", "icon_rose",1));
			themes.Add (new Theme ("ff7200", "bc0397", "0e0b08", "000000", "dot_pumpkin", "icon_pumpkin",1));
			themes.Add (new Theme ("00fff6", "ea0888", "004a80", "012946", "dot_snowflake", "icon_snowflake",1));
			themes.Add (new Theme ("5a0602", "c60101", "0e0b08", "000000", "dot_spellbinding", "icon_spellbinding",1));
			themes.Add (new Theme ("ff0004", "f8970e", "055154", "012829", "dot_tomoe", "icon_tomoe",1));
			themes.Add (new Theme ("01c4d6", "ff00ff", "440e62", "230434", "dot_cat", "icon_cat",1));
			themes.Add (new Theme ("ff0000", "00fff6", "191919", "000000", "dot_rainbow", "icon_rainbow",1));
		}
		return themes;
	}
}
