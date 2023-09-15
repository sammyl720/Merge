using NUnit.Framework;
using Merge;

namespace MergeTests
{
    [TestFixture]
    public class MergeTagTests
    {
        [Test]
        public void Merge_WithValidTags_ReturnsMergedString()
        {
            var tags = new Dictionary<string, object>
            {
                { "name", "John" },
                { "age", 30 }
            };

            var mergeTag = new MergeTag(tags);
            var result = mergeTag.Merge("Hello, <name>. You are <age> years old.");

            Assert.That(result, Is.EqualTo("Hello, John. You are 30 years old."));
        }

        [Test]
        public void Merge_WithMissingTag_ThrowsArgumentException()
        {
            var tags = new Dictionary<string, object>
            {
                { "name", "John" }
            };

            var mergeTag = new MergeTag(tags);

            Assert.Throws<ArgumentException>(() => mergeTag.Merge("Hello, <name>. You are <age> years old."));
        }

        [Test]
        public void Merge_WithCustomTags_ReturnsMergedString()
        {
            var tags = new Dictionary<string, object>
            {
                { "name", "John" },
                { "age", 30 }
            };

            var mergeTag = new MergeTag(tags, "{", "}");
            var result = mergeTag.Merge("Hello, {name}. You are {age} years old.");

            Assert.That(result, Is.EqualTo("Hello, John. You are 30 years old."));
        }

        [Test]
        public void Constructor_WithInvalidOpeningTag_ThrowsArgumentNullException()
        {
            var tags = new Dictionary<string, object>
            {
                { "name", "John" }
            };

            Assert.Throws<ArgumentNullException>(() => new MergeTag(tags, null, ">"));
        }

        [Test]
        public void Constructor_WithInvalidClosingTag_ThrowsArgumentNullException()
        {
            var tags = new Dictionary<string, object>
            {
                { "name", "John" }
            };

            Assert.Throws<ArgumentNullException>(() => new MergeTag(tags, "<", null));
        }

        [Test]
        public void Constructor_WithMismatchedTagLength_ThrowsArgumentException()
        {
            var tags = new Dictionary<string, object>
            {
                { "name", "John" }
            };

            Assert.Throws<ArgumentException>(() => new MergeTag(tags, "<", ">>"));
        }

        [Test]
        public void Constructor_WithIdenticalOpeningAndClosingTags_ThrowsArgumentException()
        {
            var tags = new Dictionary<string, object>
            {
                { "name", "John" }
            };

            Assert.Throws<ArgumentException>(() => new MergeTag(tags, "<", "<"));
        }

    }
}
