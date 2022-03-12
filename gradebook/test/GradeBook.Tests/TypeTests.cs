using System;
using Xunit;

namespace GradeBook.Tests
{
    
    public class person
    {

    }
    public struct Point
    {
        
    }
    public delegate string writetLogMessage(string logMessage);
    public class TypeTests
    {
        int count = 0 ;
        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
            writetLogMessage logMessage;
            logMessage = getResultLogMessage;
            logMessage += getResultLogMessage;
            logMessage += incremetnMessage;
            var LogMessage = logMessage("this is log message");
            Console.WriteLine(LogMessage);
            Assert.Equal(2,count);

        }
        string incremetnMessage(string msg)
        {
            count++;
            return msg.ToLower();
        }
        string getResultLogMessage(string msg)
        {
            count++;
            return msg;
        }
        [Fact]
        public void StringBehaveLikeValueTypes()
        {
            //Given
            string name = "scot";
            //When
            MakeUpperCase(ref name);
            //Then
            Assert.Equal("SCOT",name);
        }
        void MakeUpperCase(ref string str)
        {
            str =str.ToUpper();
        }
        [Fact]
        public void Test1()
        {
           var x = GetInt();
            setInt(ref x);
            
            Assert.Equal(23,x);

        }
        private int GetInt()
        {
            return 3;
            
        }
        private void setInt(ref int z)
        {
            
            z=23;
            
        }
        [Fact]
        public void CsharpCAnPassByRef()
        {
           var book1 = GetBook("book 1");
           GetBookSetName(out book1,"New Name");
            
            Assert.Equal("New Name",book1.Name);

        }
        void GetBookSetName(out Book book,string name)
        {
            book = new InMemeoryBook(name);
            
        }
        [Fact]
        public void CsharpIsPassByValue()
        {
           var book1 = GetBook("book 1");
           GetBookSetName(book1,"New Name");
            
            Assert.Equal("book 1",book1.Name);

        }
        void GetBookSetName(Book book,string name)
        {
            book = new InMemeoryBook(name);
            book.Name = name;
        }
        [Fact]
        public void CanSetNameFromReference()
        {
           var book1 = GetBook("book 1");
           setName(book1,"New Name");
            
            Assert.Equal("New Name",book1.Name);

        }
        void setName(Book book,string name)
        {
            book.Name = name;
        }
        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
           var book1 = GetBook("book 1");
           var book2 = GetBook("book 2");
            
            Assert.Equal("book 1",book1.Name);
            Assert.Equal("book 2",book2.Name);
            Assert.NotSame(book1,book2);
        }
        [Fact]
        public void GetBookReturnSameObjects()
        {
           var book1 = GetBook("book 1");
           var book2 = book1;
            
            Assert.Same(book1,book2);
            Assert.True(Object.ReferenceEquals(book1,book2));
        }
        Book GetBook(string name)
        {
            return new InMemeoryBook(name);
        }
    }
}
