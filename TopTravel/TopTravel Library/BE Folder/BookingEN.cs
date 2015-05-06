using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HadaProject.Models
{
	public class BookingEN
	{
		public BookingEN(int id, int user, int product)
		{
			BookingId = id;
			BookingProduct = product;
			BookingUserId = user;
		}

		public void add_Booking()
		{
			m_cc = new BookingCAD();
			m_cc.add_Booking(this);
		}
		
		public void delete_Booking()
		{
			m_cc = new BookingCAD();
			m_cc.delete_Booking(this);
		}
		
		public void update_Booking()
		{
			m_cc = new BookingCAD();
			m_cc.update_Booking(this);
		}
		
		public void search_Booking()
		{
			m_cc = new BookingCAD();
			m_cc.search_Booking(this);
		}
		//PROPERTIES
		public int BookingId { get; set; }
		public int BookingUserId { get; set; }
		public int BookingProduct { get; set; }

		//Data
		private BookingCAD m_cc;
	}
}