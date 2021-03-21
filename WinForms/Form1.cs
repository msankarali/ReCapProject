using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using Entities.Concrete;
using Core.Utilities.RestSharp;
using WebApplication1.Models;
using Entities.DTOs;
using Core.Utilities.Security.Jwt;

namespace WinForms
{
    public partial class Form1 : Form
    {
        private IHttpContextAccessor _httpContextAccessor;
        private readonly IApiService _apiService;
        public Form1()
        {
            InitializeComponent();
            _apiService = ServiceTool.ServiceProvider.GetService<IApiService>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //_httpRequestHelper.Get<List<Brand>>("brands/getbrands")
            var result = _apiService.Get<ViewDataResult<List<Car>>>("cars/getall");

            result.Data.ForEach(car =>
            {
                listBox1.Items.Add($"{car.CarName} {car.DailyPrice} {car.Description} {car.ModelYear}");
            });

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var result = _apiService.Post<AccessToken>("auth/login", new UserForLoginDto
            {
                Email = textBox1.Text,
                Password = textBox2.Text
            });

            if (result is not null)
            {
                _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
                _httpContextAccessor.HttpContext.Request.Headers.Add("Bearer", result.Token);
                MessageBox.Show("basarili");

                var result2 = _apiService.Post<ViewDataResult<Car>>("cars/add", new Car
                {
                    BrandId = 1,
                    CarId = 2,
                    CarName = "BMW",
                    ColorId = 1,
                    DailyPrice = 100,
                    Description = "BMW",
                    ModelYear = 2010
                });
            }
            else
            {
                MessageBox.Show("Parola yanlis");
            }
        }
    }
}
