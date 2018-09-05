using System;
using Xunit;
using csharp_exercise;
namespace test_csharp_exercise
{
    public class TestMerger
    {
        [Fact]
        public void TestMergeTwoNullList()
        {

            Assert.Null(Merger.Merge(null, null));
        }
        [Fact]
        public void TestMergeOneNullList()
        {
            Node h1= new Node();
            h1.data = 1;


            Node h2 = null;
            Node merged = Merger.Merge(h1, h2);

            int[] expected = new int[] { 1 };

            Assert.True(IsLinkedListExpected(merged, expected));

        }

        [Fact]
        public void TestMergeTwoSeparatedOrderedList()
        {
            Node h1 = PrepareNodes(new int[] { 1, 2});
            Node h2 = PrepareNodes(new int[] { 3, 4 });
            Node merged = Merger.Merge(h1, h2);
            int[] expected = new int[] { 1, 2, 3, 4 };
            Assert.True(IsLinkedListExpected(merged, expected));
        }
        [Fact]
        public void TestMergeTwoMixinOrderedList()
        {
            Node h1 = PrepareNodes(new int[] { 1, 2, 5 });
            Node h2 = PrepareNodes(new int[] { 3, 4 });
            Node merged = Merger.Merge(h1, h2);
            int[] expected = new int[] { 1, 2, 3, 4, 5 };
            Assert.True(IsLinkedListExpected(merged, expected));
        }

        [Fact]
        public void TestMergeTwoSeparatedOrderedListWithDuplicates()
        {
            Node h1 = PrepareNodes(new int[] { 1,1, 2,3 });
            Node h2 = PrepareNodes(new int[] { 3, 4,5,6 });
            Node merged = Merger.Merge(h1, h2);
            int[] expected = new int[] { 1, 1, 2, 3, 3,4,5,6 };
            Assert.True(IsLinkedListExpected(merged, expected));

        }
        [Fact]
        public void TestMergeTwoMixinOrderedListWithDuplicates()
        {
            Node h1 = PrepareNodes(new int[] { 1, 2, 2, 5 });
            Node h2 = PrepareNodes(new int[] { 3, 3, 4 });
            Node merged = Merger.Merge(h1, h2);
            int[] expected = new int[] { 1, 2, 2, 3, 3, 4, 5};
            Assert.True(IsLinkedListExpected(merged, expected));

        }

        private static bool IsLinkedListExpected(Node merged, int[] expected)
        {
            int i = 0;
            while (merged != null)
            {
                Assert.Equal(expected[i], merged.data);
                merged = merged.next;
                i++;
            }
            Assert.Equal(expected.Length, i);
            return true;
        }
        private static Node PrepareNodes(int[] array)
        {
            if (array == null || array.Length ==0 )
                return null;

            Node head = null ;
            Node current = null;
            Node previous = null;
            for (int i = 0; i < array.Length; i++)
            {
                current = new Node();

                current.data = array[i];
                if (i == array.Length - 1)
                    current.next = null;

                if (i == 0)
                    head = current;
                else
                    previous.next = current;


                previous = current;
            }
            return head;
        }
    }
}
