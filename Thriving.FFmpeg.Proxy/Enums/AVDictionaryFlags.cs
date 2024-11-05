namespace Thriving.FFmpeg.Proxy
{
    [Flags]
    public enum AVDictionaryFlags
    {
        /// <summary>
        /// <code>Only relevant in av_dict_get()</code>
        /// <code>Only get an entry with exact-case key match</code>
        /// </summary>
        AV_DICT_MATCH_CASE = 1,
        /// <summary>
        /// <code>Only relevant in av_dict_get()</code>
        /// <code>Return first entry in a dictionary whose first part corresponds to the search key ignoring the suffix of the found key string</code>
        /// </summary>
        AV_DICT_IGNORE_SUFFIX = 2,
        /// <summary>
        /// Take ownership of a key that's been        allocated with av_malloc() or another memory allocation function
        /// </summary>
        AV_DICT_DONT_STRDUP_KEY = 4,
        /// <summary>
        /// Take ownership of a value that's been        allocated with av_malloc() or another memory allocation function
        /// </summary>
        AV_DICT_DONT_STRDUP_VAL = 8,
        /// <summary>
        /// Don't overwrite existing entries
        /// </summary>
        AV_DICT_DONT_OVERWRITE = 16,
        /// <summary>
        /// If the entry already exists, append to it.Note that no delimiter is added, the strings are simply concatenated
        /// </summary>
        AV_DICT_APPEND = 32,
        /// <summary>
        /// Allow to store several equal keys in the dictionary
        /// </summary>
        AV_DICT_MULTIKEY = 64
    }
}