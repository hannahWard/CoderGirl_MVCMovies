﻿using CoderGirl_MVCMovies;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Reflection;
using System.IO;
using OpenQA.Selenium.Support.UI;
using System.Linq;

namespace Test
{
    public class TestMovieRatingViews : IDisposable
    {
        private ChromeDriver driver;
        private const string BASE_URL = "http://localhost:59471";


        public TestMovieRatingViews()
        {
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
        }

        [Theory]
        [InlineData("Star Wars", "5")]
        [InlineData("Princess Bride", "4")]
        public void TestCreateMovieRating(string movieName, string rating)
        {
            //add movies to data
            driver.Url = BASE_URL + "/movie/create";
            driver.FindElementByName("movie").SendKeys(movieName);
            var movieForm = driver.FindElementByTagName("form");
            var movieSubmit = movieForm.FindElement(By.TagName("button"));
            movieSubmit.Click();

            //navigate to add movie rating page and get elements
            driver.Url = BASE_URL + "/movierating/create";
            var form = driver.FindElementByTagName("form");
            var submit = form.FindElement(By.TagName("button"));
            Assert.Equal("submit", submit.GetAttribute("type"));
            Assert.Equal("Add Movie", submit.Text);
            var movieSelectInput = new SelectElement(driver.FindElementByName("Movie"));
            var ratingSelectInput = new SelectElement(driver.FindElementByName("Rating"));

            //make selections for input and submit
            movieSelectInput.SelectByText(movieName);
            ratingSelectInput.SelectByText(rating);
            submit.Click();

            //verify it redirects to Index
            Assert.Equal(Uri.EscapeUriString(BASE_URL + $"/movierating"), driver.Url, true);

            //navigate to movie rating list page and get table rows
            driver.Url = BASE_URL + "/movierating";
            var rows = driver.FindElementsByTagName("tr");
            var headers = rows[0].FindElements(By.TagName("th"));
            var source = driver.PageSource;

            //Verify the first row has proper headers
            Assert.Equal("Movie",  headers[0].Text);
            Assert.Equal("Rating", headers[1].Text);

            //Verify a row contains expected movie/rating combo
            Assert.Contains(rows, row => RowMatches(row, movieName, rating));
        }

        private bool RowMatches(IWebElement row, string name, string rating)
        {
            var tdElements = row.FindElements(By.TagName("td"));
            if (tdElements.Count < 2) return false;

            return tdElements[0].Text == name && tdElements[1].Text == rating;
        }

        public void Dispose()
        {
            driver.Close();
            driver.Dispose();
        }
    }
}
