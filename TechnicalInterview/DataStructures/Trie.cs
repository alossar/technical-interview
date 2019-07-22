namespace TechnicalInterview.DataStructures
{
    public class Trie
    {
        class TrieNode
        {
            public TrieNode[] Children { get; set; }
            public bool IsWord { get; set; }

            public TrieNode()
            {
                Children = new TrieNode[26];
            }
        }

        private TrieNode root;

        /** Initialize your data structure here. */
        public Trie()
        {
            root = new TrieNode();
        }

        /** Inserts a word into the trie. */
        public void Insert(string word)
        {
            TrieNode current = root;
            for (int i = 0; i < word.Length; i++)
            {
                if (current.Children[word[i] - 'a'] == null) current.Children[word[i] - 'a'] = new TrieNode();
                current = current.Children[word[i] - 'a'];
            }
            current.IsWord = true;
        }

        /** Returns if the word is in the trie. */
        public bool Search(string word)
        {
            TrieNode current = root;
            for (int i = 0; i < word.Length; i++)
            {
                if (current.Children[word[i] - 'a'] == null) return false;
                current = current.Children[word[i] - 'a'];
            }
            return current.IsWord;
        }

        /** Returns if there is any word in the trie that starts with the given prefix. */
        public bool StartsWith(string prefix)
        {
            TrieNode current = root;
            for (int i = 0; i < prefix.Length; i++)
            {
                if (current.Children[prefix[i] - 'a'] == null) return false;
                current = current.Children[prefix[i] - 'a'];
            }
            return true;
        }
    }
}
