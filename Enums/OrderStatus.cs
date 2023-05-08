using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace CheeseBurger.Enums
{
	public enum OrderStatus
	{
		[Display(Name = "Chờ xác nhận")]
		waiting = 1,
		[Display(Name = "Đang chuẩn bị")]
		preparing,
		[Display(Name = "Chờ giao")]
		prepareDone,
		[Display(Name = "Đang giao")]
		shipping,
		[Display(Name = "Đã giao")]
		completed,
		[Display(Name = "Không thành công")]
		closed,
		[Display(Name = "Đã huỷ")]
		canceled
	}
	public static class EnumExtensions
	{
		public static string GetDisplayName(this Enum enumValue)
		{
			return enumValue.GetType()
			  .GetMember(enumValue.ToString())
			  .First()
			  .GetCustomAttribute<DisplayAttribute>()
			  ?.GetName();
		}
	}
}
