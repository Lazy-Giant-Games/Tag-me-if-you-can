using UnityEngine;

namespace TagMeIfYouCan {

	public class ObjectPoolLibraryCommon : MonoSingleton<ObjectPoolLibraryCommon> {

        public enum PoolType { NULL, TRAIL };

        public ObjectPoolManager[] objectPoolers;

		public ObjectPoolManager GetObjectPooler(PoolType poolerType) {
			if (objectPoolers == null || objectPoolers.Length <= 0)
				return null;
			return objectPoolers[(int)poolerType];
		}
	}
}