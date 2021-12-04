using AutoMapper;
using CapsuleHotels.Data.Repositories.Contracts;
using CapsuleHotels.Dtos.Entites;
using CapsuleHotels.Dtos.ResourceParameters;
using CapsuleHotels.Services.Business;
using CapsuleHotels.Services.Business.Contracts;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace CapsuleHotels.Test
{
    public class ReservasTest 
    {
        [Fact]
        public async void GetReservasRangoAsyncTest()
        {
            //Arregae
            IMapper mapper = mapperMock();
            IReservaRepository reservaRepository = reservaRepositoryMock();
            IUsuarioService usuarioService = usuarioServiceMock();
            IHotelService hotelService = hotelServiceMock();
            IHabitacionService habitacionService = habitacionServiceMock();
            ILogger<ReservaService> logger = loggerMock();

            var request = new ReservasSearchResourceParameters
            {
                HotelId = 1,
                CheckIn = new DateTime(2021, 12, 1),
                CheckOut = new DateTime(2021, 12, 31)
            };

            var action = new ReservaService(mapper, reservaRepository, usuarioService, hotelService, habitacionService, logger);

            //Act
            var result =await action.GetReservasRangoAsync(request);

            //Assert
            //Comprobamos que el resultado no sea null y que es del tipo que queremos
            Assert.NotNull(result);
            Assert.IsType<ReservaDto[]>(result);

        }

        //Dependency injection
        private IMapper mapperMock()
        {
            Mock<IMapper> mockObject = new Mock<IMapper>();
            return mockObject.Object;
        }
        private IReservaRepository reservaRepositoryMock()
        {
            Mock<IReservaRepository> mockObject = new Mock<IReservaRepository>();
            return mockObject.Object;
        }
        private IUsuarioService usuarioServiceMock()
        {
            Mock<IUsuarioService> mockObject = new Mock<IUsuarioService>();
            return mockObject.Object;
        }
        private IHotelService hotelServiceMock()
        {
            Mock<IHotelService> mockObject = new Mock<IHotelService>();
            return mockObject.Object;
        }
        private IHabitacionService habitacionServiceMock()
        {
            Mock<IHabitacionService> mockObject = new Mock<IHabitacionService>();
            return mockObject.Object;
        }
        private ILogger<ReservaService> loggerMock()
        {
            Mock<ILogger<ReservaService>> mockObject = new Mock<ILogger<ReservaService>>();
            return mockObject.Object;
        }
    }
}
