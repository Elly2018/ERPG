using ERPG;
using UnityEngine;

public class DatabaseManager : MonoBehaviour
{
    private void Awake()
    {
        DBCollection.Initialize();

        DBCollection.DB_Language.Load(
            DBCollection.DB_Language.GetLanguagePath(PrefabRegisterStruct.GetPrefabRegisterStruct().data.LanguageTag)
            );

        DataBasePlayer b = new DataBasePlayer();
        b.PlayerName = "Tuna";
        b.Properties.Add(new Health(100));
        b.Properties.Add(new MaximumHealth(100));
        b.Properties.Add(new Mana(100));
        b.Properties.Add(new MaximumMana(100));
        b.Properties.Add(new Damage(25));
        DBCollection.DB_Player.value.Elements.Add(b);
        DBCollection.DB_Player.Save(
            PlayerDatabase.DataPath
            );

        DBCollection.DB_Player.Load(
            PlayerDatabase.DataPath
            );

        Debug.Log(DBCollection.DB_Player.value.Elements[0].PlayerName);
        Debug.Log(DBCollection.DB_Player.value.Elements[0].Properties.ToString());
    }
}
