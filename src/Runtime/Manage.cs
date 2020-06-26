using UnityEngine;

namespace ERPG
{
    public class Manage
    {
        #region Spawn

        #region Monster
        /// <summary>
        /// Spawn a monster prefab
        /// </summary>
        /// <param name="target">Monster register</param>
        /// <param name="position">Position</param>
        /// <returns>Monster instance</returns>
        public static GameObject SpawnMonster(SearchTerm target, Vector3 position)
        {
            GameObject g = GetRegisterMonsterByKeyword(target);
            if (g == null)
                return null;
            return GameObject.Instantiate(g, position, Quaternion.identity);
        }

        /// <summary>
        /// Spawn a monster prefab
        /// </summary>
        /// <param name="target">Monster register</param>
        /// <param name="position">Position</param>
        /// <param name="rotation">Rotation</param>
        /// <returns>Monster instance</returns>
        public static GameObject SpawnMonster(SearchTerm target, Vector3 position, Quaternion rotation)
        {
            GameObject g = GetRegisterMonsterByKeyword(target);
            if(g == null)
                return null;
            return GameObject.Instantiate(g, position, rotation);
        }

        /// <summary>
        /// Spawn a monster prefab
        /// </summary>
        /// <param name="target">Monster register</param>
        /// <param name="position">Position</param>
        /// <param name="rotation">Rotation</param>
        /// <param name="scale">Scale</param>
        /// <returns>Monster instance</returns>
        public static GameObject SpawnMonster(SearchTerm target, Vector3 position, Quaternion rotation, Vector3 scale)
        {
            GameObject g = GetRegisterMonsterByKeyword(target);
            if (g == null)
                return null;
            GameObject buffer = GameObject.Instantiate(g, position, rotation);
            buffer.transform.localScale = scale;
            return buffer;
        }
        #endregion

        #region Player
        /// <summary>
        /// Spawn a monster prefab
        /// </summary>
        /// <param name="target">Player register</param>
        /// <param name="position">Position</param>
        /// <returns>Player instance</returns>
        public static GameObject SpawnPlayer(SearchTerm target, Vector3 position)
        {
            GameObject g = GetRegisterPlayerByKeyword(target);
            if (g == null)
                return null;
            return GameObject.Instantiate(g, position, Quaternion.identity);
        }

        /// <summary>
        /// Spawn a monster prefab
        /// </summary>
        /// <param name="target">Player register</param>
        /// <param name="position">Position</param>
        /// <param name="rotation">Rotation</param>
        /// <returns>Player instance</returns>
        public static GameObject SpawnPlayer(SearchTerm target, Vector3 position, Quaternion rotation)
        {
            GameObject g = GetRegisterPlayerByKeyword(target);
            if (g == null)
                return null;
            return GameObject.Instantiate(g, position, rotation);
        }

        /// <summary>
        /// Spawn a monster prefab
        /// </summary>
        /// <param name="target">Player register</param>
        /// <param name="position">Position</param>
        /// <param name="rotation">Rotation</param>
        /// <param name="scale">Scale</param>
        /// <returns>Player instance</returns>
        public static GameObject SpawnPlayer(SearchTerm target, Vector3 position, Quaternion rotation, Vector3 scale)
        {
            GameObject g = GetRegisterPlayerByKeyword(target);
            if (g == null)
                return null;
            GameObject buffer = GameObject.Instantiate(g, position, rotation);
            buffer.transform.localScale = scale;
            return buffer;
        }
        #endregion

        #region Material
        /// <summary>
        /// Spawn a materal prefab
        /// </summary>
        /// <param name="target">Material register</param>
        /// <param name="position">Position</param>
        /// <returns>Material instance</returns>
        public static GameObject SpawnMaterial(SearchTerm target, Vector3 position)
        {
            GameObject g = GetRegisterMaterialByKeyword(target);
            if (g == null)
                return null;
            return GameObject.Instantiate(g, position, Quaternion.identity);
        }

        /// <summary>
        /// Spawn a materal prefab
        /// </summary>
        /// <param name="target">Material register</param>
        /// <param name="position">Position</param>
        /// <param name="rotation">Rotation</param>
        /// <returns>Material instance</returns>
        public static GameObject SpawnMaterial(SearchTerm target, Vector3 position, Quaternion rotation)
        {
            GameObject g = GetRegisterMaterialByKeyword(target);
            if (g == null)
                return null;
            return GameObject.Instantiate(g, position, rotation);
        }

        /// <summary>
        /// Spawn a materal prefab
        /// </summary>
        /// <param name="target">Material register</param>
        /// <param name="position">Position</param>
        /// <param name="rotation">Rotation</param>
        /// <param name="scale">Scale</param>
        /// <returns>Material instance</returns>
        public static GameObject SpawnMaterial(SearchTerm target, Vector3 position, Quaternion rotation, Vector3 scale)
        {
            GameObject g = GetRegisterMaterialByKeyword(target);
            if (g == null)
                return null;
            GameObject buffer = GameObject.Instantiate(g, position, rotation);
            buffer.transform.localScale = scale;
            return buffer;
        }
        #endregion

        #endregion

        #region DataBase
        /// <summary>
        /// Search database and get the data table of this player
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Player GetPlayerDatabaseByID(string id)
        {

            return null;
        }
        #endregion

        #region Utility
        /// <summary>
        /// Get the keypoint transform by search word
        /// </summary>
        /// <param name="target">Key point search term</param>
        /// <returns>Key point transform</returns>
        public static Transform GetKeyPoint(SearchTerm target)
        {
            foreach(var i in GameObject.FindObjectsOfType<Keypoint>())
            {
                if (i.Keyword == target) return i.transform;
            }
            return null;
        }
        #endregion

        #region Private Getter
        /// <summary>
        /// Search register struct and find match monster keyword game object
        /// </summary>
        /// <param name="target">Search word</param>
        /// <returns></returns>
        private static GameObject GetRegisterMonsterByKeyword(SearchTerm target)
        {
            PrefabRegisterStruct registerStruct = PrefabRegisterStruct.GetPrefabRegisterStruct().data;
            foreach(var i in registerStruct.CreaturesRegister.Monster)
            {
                if (i.GetComponent<PrefabRegister>())
                {
                    if (i.GetComponent<PrefabRegister>().Keyword == target) return i;
                }
            }
            Logger.LogError("Manage", "Error", "Cannot find monster by keyword: " + target.ToString());
            return null;
        }

        /// <summary>
        /// Search register struct and find match player keyword game object
        /// </summary>
        /// <param name="target">Search word</param>
        /// <returns></returns>
        private static GameObject GetRegisterPlayerByKeyword(SearchTerm target)
        {
            PrefabRegisterStruct registerStruct = PrefabRegisterStruct.GetPrefabRegisterStruct().data;
            foreach (var i in registerStruct.CreaturesRegister.Player)
            {
                if (i.GetComponent<PrefabRegister>())
                {
                    if (i.GetComponent<PrefabRegister>().Keyword == target) return i;
                }
            }
            Logger.LogError("Manage", "Error", "Cannot find monster by keyword: " + target.ToString());
            return null;
        }

        /// <summary>
        /// Search register struct and find match materal keyword game object
        /// </summary>
        /// <param name="target">Search word</param>
        /// <returns></returns>
        private static GameObject GetRegisterMaterialByKeyword(SearchTerm target)
        {
            PrefabRegisterStruct registerStruct = PrefabRegisterStruct.GetPrefabRegisterStruct().data;
            foreach (var i in registerStruct.EnviromentRegister.Materals)
            {
                if (i.GetComponent<PrefabRegister>())
                {
                    if (i.GetComponent<PrefabRegister>().Keyword == target) return i;
                }
            }
            Logger.LogError("Manage", "Error", "Cannot find materal by keyword: " + target.ToString());
            return null;
        }
        #endregion
    }
}
