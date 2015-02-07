using Cielo.Helpers;
using Cielo.Messages;
using System;
using System.Xml.Serialization;
using Xunit;
using Xunit.Extensions;

namespace Cielo.Tests.Unit.Helpers
{
    public class XmlTests
    {
        public class ToXml
        {
            [Fact]
            public void ReturnsNullGivenNullInput()
            {
                // arrange
                Dummy requisicaoTransacao = null;

                // act
                var actual = requisicaoTransacao.ToXml();

                // assert
                Assert.Null(actual);
            }

            [Fact]
            public void ReturnsCorrectXmlGivenDummyClass()
            {
                // arrage
                var expected = "﻿<?xml version=\"1.0\" encoding=\"utf-8\"?><dummy xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" id=\"102\"><full-name>Walter White</full-name></dummy>";
                var dummy = new Dummy { Id = 102, FullName = "Walter White" };

                //act
                var actual = dummy.ToXml();

                // assert
                Assert.Equal(expected, actual);
            }
        }

        public class ToType
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            [InlineData(" ")]
            public void ReturnsNullGivenNullOrWhiteSpaceInput(string strXml)
            {
                // arrange
                // act
                var actual = strXml.ToType<Dummy>();

                // assert
                Assert.Null(actual);
            }

            [Fact]
            public void ReturnsCorrectObjectGivenXmlString()
            { 
                // arrange
                var xmlString = "﻿<?xml version=\"1.0\" encoding=\"utf-8\"?><dummy xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" id=\"102\"><full-name>Walter White</full-name></dummy>";
                
                var expectedId = 102;
                var expectedFullName = "Walter White";

                // act
                var actual = xmlString.ToType<Dummy>();

                // assert
                Assert.NotNull(actual);
                Assert.Equal(expectedId, actual.Id);
                Assert.Equal(expectedFullName, actual.FullName);
            }
        }

        [SerializableAttribute()]
        [XmlRootAttribute("dummy")]
        public class Dummy
        {
            [XmlAttribute("id")]
            public int Id { get; set; }

            [XmlElement("full-name")]
            public string FullName { get; set; }
        }
    }
}
