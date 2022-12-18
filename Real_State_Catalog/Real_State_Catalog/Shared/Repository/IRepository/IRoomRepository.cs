using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Real_State_Catalog.Shared.Repository.IRepository
{
    public interface IRoomRepository
    {

        //Create a new hotel room DTO, then return that DTO
    public Task<RoomDTO> CreateRoom(RoomDTO hotelRoomDTO);

        //Update hotel
        public Task<RoomDTO> UpdateRoom(int roomId,RoomDTO hotelRoomDTO);

        //Get individiaul hotel
        public Task<RoomDTO> GetRoom(int roomId, string checkIn = null, string checkOut = null);
        public Task<int> DeleteRoom(int roomId);


        //Get all hotels
        public Task<IEnumerable<RoomDTO>> GetAllRoom(string checkIn = null, string checkOut = null);

        //Get the name of the hotel room to validate booking

        public Task<bool> IsBooked(int RoomId, string checkInDate, string checkOutDate);

    }
}
