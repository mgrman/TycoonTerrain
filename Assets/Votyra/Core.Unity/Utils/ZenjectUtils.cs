using UnityEngine;
using Zenject;

namespace Votyra.Core.Utils
{
    public static class ZenjectUtils
    {
        public static ScopeArgConditionCopyNonLazyBinder FromNewComponentOnGameObjectWithID(this FromBinder binder, string id)
        {
            return binder.FromNewComponentOn(c => c.Container.ResolveId<GameObject>(id));
        }
    }
}