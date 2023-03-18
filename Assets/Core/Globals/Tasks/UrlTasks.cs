using UnityEngine;

namespace Core.Globals.Tasks
{
    public static class UrlTasks
    {
        public static void OpenUrl(string url)
        {
            Application.OpenURL(url);
        }
    }
}
