using System.Text;

namespace Merge;
/// <summary>
/// Represents a utility class for merging tags within a string.
/// </summary>
public class MergeTag
{
    private readonly string openingTag;
    private readonly string closingTag;
    private readonly Dictionary<string, object> tags;

    /// <summary>
    /// Initializes a new instance of the <see cref="MergeTag"/> class with default opening and closing tags.
    /// </summary>
    /// <param name="tags">The dictionary of tags and their associated values.</param>
    public MergeTag(Dictionary<string, object> tags) : this(tags, "<", ">") { }

    /// <summary>
    /// Initializes a new instance of the <see cref="MergeTag"/> class with custom opening and closing tags.
    /// </summary>
    /// <param name="tags">The dictionary of tags and their associated values.</param>
    /// <param name="openingTag">The opening tag.</param>
    /// <param name="closingTag">The closing tag.</param>
    public MergeTag(Dictionary<string, object> tags, string openingTag, string closingTag)
    {
        ValidateTags(openingTag, closingTag);
        this.tags = tags;
        this.openingTag = openingTag;
        this.closingTag = closingTag;
    }

    /// <summary>
    /// Validates the opening and closing tags.
    /// </summary>
    /// <param name="openingTag">The opening tag.</param>
    /// <param name="closingTag">The closing tag.</param>
    private void ValidateTags(string openingTag, string closingTag)
    {
        if (string.IsNullOrEmpty(openingTag) || string.IsNullOrEmpty(closingTag))
        {
            throw new ArgumentNullException("Tags cannot be empty or null");
        }

        if (openingTag.Length != closingTag.Length)
        {
            throw new ArgumentException("Opening and closing tags should be the same length");
        }

        if (openingTag == closingTag)
        {
            throw new ArgumentException("Opening and closing tags should not be the same");
        }
    }

    /// <summary>
    /// Merges the tags within the given input string.
    /// </summary>
    /// <param name="input">The input string containing tags to be merged.</param>
    /// <returns>The merged string.</returns>
    public string Merge(string input)
    {
        StringBuilder result = new StringBuilder();
        StringBuilder keyBuilder = new StringBuilder();
        bool isBuildingKey = false;

        for (int i = 0; i < input.Length; i++)
        {
            string currentSubstring = input.Substring(i, Math.Min(openingTag.Length, input.Length - i));

            if (currentSubstring == openingTag)
            {
                if (isBuildingKey)
                {
                    result.Append(input[i]);
                    continue;
                }

                isBuildingKey = true;
                i += openingTag.Length - 1;
            }
            else if (currentSubstring == closingTag)
            {
                if (!isBuildingKey)
                {
                    result.Append(input[i]);
                    continue;
                }

                string key = keyBuilder.ToString();
                if (!tags.ContainsKey(key))
                {
                    throw new ArgumentException($"Cannot find tag for {key} in provided dictionary");
                }

                result.Append(tags[key].ToString());
                keyBuilder.Clear();
                isBuildingKey = false;
                i += closingTag.Length - 1;
            }
            else
            {
                if (isBuildingKey)
                {
                    keyBuilder.Append(input[i]);
                }
                else
                {
                    result.Append(input[i]);
                }
            }
        }

        return result.ToString();
    }
}
