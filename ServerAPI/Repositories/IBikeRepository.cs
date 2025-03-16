using System;
using Core;
namespace ServerAPI.Repositories
{
	public interface IBikeRepository
	{
		BEBike[] GetAll();
		void Add(BEBike bike);
	}
}

