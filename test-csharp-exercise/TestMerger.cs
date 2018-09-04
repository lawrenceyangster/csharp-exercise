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
            Merger merger = new Merger();
            Assert.Null(merger.Merge(null, null));
        }
        [Fact]
        public void TestMergeOneNullList()
        {
            csharp_exercise.Node h1= new Node();
            h1.data = 1;
            h1.next = null;
            csharp_exercise.Node h2 = null;

            Merger merger = new Merger();

            Assert.Equal(h1, merger.Merge(h1, h2));
            Assert.Equal(h1, merger.Merge(h2, h1));

        }

        [Fact]
        public void TestMergeTwoSeparatedOrderedList()
        {
            Node h1 = PrepareNodes(new int[] {1,2});
            Node h2 = PrepareNodes(new int[] { 3, 4 });
            Node merged = new Merger().Merge(h1, h2);
            int[] expected = new int[] { 1, 2, 3, 4 };
            IsLinkedListExpected(merged, expected);
        }
        [Fact]
        public void TestMergeTwoMixinOrderedList()
        {
            Node h1 = PrepareNodes(new int[] { 1, 2, 5 });
            Node h2 = PrepareNodes(new int[] { 3, 4 });
            Node merged = new Merger().Merge(h1, h2);
            int[] expected = new int[] { 1, 2, 3, 4, 5 };
            IsLinkedListExpected(merged, expected);
        }

        [Fact]
        public void TestMergeTwoOrderedListWithDuplicates()
        {
            Node h1 = PrepareNodes(new int[] { 1,1, 2,3 });
            Node h2 = PrepareNodes(new int[] { 3, 4,5,6 });
            Node merged = new Merger().Merge(h1, h2);
            int[] expected = new int[] { 1, 1,2, 3, 3,4,5,6 };
            IsLinkedListExpected(merged, expected);

        }
        private void IsLinkedListExpected(Node merged, int[] expected)
        {
            int i = 0;
            while (merged != null)
            {
                Assert.Equal(expected[i], merged.data);
                merged = merged.next;
                i++;
            }
            Assert.Equal(expected.Length, i);

        }
        private Node PrepareNodes(int[] array)
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
