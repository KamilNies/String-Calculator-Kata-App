using String_Calculator_Kata;
using System;
using Xunit;

namespace String_Calculator_Kata_Test
{
    public class StringCalculatorTest
    {
        [Fact]
        public void Should_Return_0_If_Input_String_Is_Empty_String()
        {
            var stringCalculator = new StringCalculator();
            var result = stringCalculator.Add("");

            Assert.Equal(0, result);
        }

        [Fact]
        public void Should_Return_2_If_Input_String_Is_2()
        {
            var stringCalculator = new StringCalculator();
            var result = stringCalculator.Add("2");

            Assert.Equal(2, result);
        }

        [Fact]
        public void Should_Return_22_If_Input_String_Is_22()
        {
            var stringCalculator = new StringCalculator();
            var result = stringCalculator.Add("22");

            Assert.Equal(22, result);
        }

        [Fact]
        public void Should_Return_5_If_Input_String_Is_2_comma_3()
        {
            var stringCalculator = new StringCalculator();
            var result = stringCalculator.Add("2,3");

            Assert.Equal(5, result);
        }

        [Fact]
        public void Should_Return_12_If_Input_String_Is_10_comma_2()
        {
            var stringCalculator = new StringCalculator();
            var result = stringCalculator.Add("10,2");

            Assert.Equal(12, result);
        }

        [Fact]
        public void Should_Return_9_If_Input_String_Is_2_3_4()
        {
            var stringCalculator = new StringCalculator();
            var result = stringCalculator.Add("2,3,4");

            Assert.Equal(9, result);
        }

        [Fact]
        public void Should_Return_13_If_Input_String_Is_4_negativ1_2_6_0()
        {
            var stringCalculator = new StringCalculator();
            var result = stringCalculator.Add("4,1,2,6,0");

            Assert.Equal(13, result);
        }

        [Fact]
        public void Should_Return_6_If_Input_String_Is_1_NewLine2_3()
        {
            var stringCalculator = new StringCalculator();
            var result = stringCalculator.Add("1\n2,3");

            Assert.Equal(6, result);
        }

        [Fact]
        public void Should_Return_3_If_Input_String_Is_Delimiter_1_2()
        {
            var stringCalculator = new StringCalculator();
            var result = stringCalculator.Add("//;\n1;2");

            Assert.Equal(3, result);
        }

        [Fact]
        public void Should_Throw_Exception_If_String_Contains_Negativ_Numbers()
        {
            var stringCalculator = new StringCalculator();
            Assert.Throws<ArgumentException>(() => stringCalculator.Add("1,2,-1"));
        }

        [Fact]
        public void Should_Return_ArgumentException_Message_Negatives_Not_Allowed()
        {
            var stringCalculator = new StringCalculator();
            var ae = Assert.Throws<ArgumentException>(() => stringCalculator.Add("1,-2,11, 2"));
            
            Assert.Equal("negatives not allowed -2", ae.Message);
        }

        [Fact]
        public void Should_Return_ArgumentException_Message_With_All_Negativ_Numbers()
        {
            var stringCalculator = new StringCalculator();
            var ae = Assert.Throws<ArgumentException>(() => stringCalculator.Add("1,-2,3,-2,-4, 2"));

            Assert.Equal("negatives not allowed -2,-2,-4", ae.Message);
        }

        [Fact]
        public void Should_Return_9_If_Input_String_Is_2_3_4_1001_1323()
        {
            var stringCalculator = new StringCalculator();
            var result = stringCalculator.Add("2,3,4,1001,1323");

            Assert.Equal(9, result);
        }

        [Fact]
        public void Should_Return_2906_If_Input_String_Is_1_5_1000_1001_4000_900_1000()
        {
            var stringCalculator = new StringCalculator();
            var result = stringCalculator.Add("1,5,1000,1001,4000,900,1000");

            Assert.Equal(2906, result);
        }

        [Fact]
        public void Should_Return_6_If_Input_String_Is_Delimiter_1_2_3()
        {
            var stringCalculator = new StringCalculator();
            var result = stringCalculator.Add("//[***]\n1***2***3");

            Assert.Equal(6, result);
        }

        [Fact]
        public void Should_Return_8_If_Input_String_Is_Delimiter_2_3()
        {
            var stringCalculator = new StringCalculator();
            var result = stringCalculator.Add("//[;.fd]\n1;.fd2;.fd5");

            Assert.Equal(8, result);
        }

        [Fact]
        public void Should_Return_6_If_Input_String_Is_Delimiter_Delimiter_1_2_3()
        {
            var stringCalculator = new StringCalculator();
            var result = stringCalculator.Add("//[*][%]\n1*2%3");

            Assert.Equal(6, result);
        }

        [Fact]
        public void Should_Return_11_If_Input_String_Is_Delimiter_Delimiter_Delimiter_1_2_3_5()
        {
            var stringCalculator = new StringCalculator();
            var result = stringCalculator.Add("//[*][%][;]\n1*2%3;5");

            Assert.Equal(11, result);
        }

        [Fact]
        public void Should_Return_19_If_Input_String_Is_Delimiter_Delimiter_Delimiter_Delimiter_1_2_3_5_8()
        {
            var stringCalculator = new StringCalculator();
            var result = stringCalculator.Add("//[**][df%][f;][.]\n1**2df%3f;5.8");

            Assert.Equal(19, result);
        }

    }
}