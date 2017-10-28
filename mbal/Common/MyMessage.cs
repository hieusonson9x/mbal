using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mbal.Common
{
    public class MyMessage
    {
        /*
         * common
         */
        public const string INVALID_DATA = "Dữ liệu không hợp lệ";
        public const string ADD_SUCCESS = "Thêm thành công";

        /*
         * khách hàng
         */
        public const string ERROR_ADD_CUSTOMER = "Thêm thất bại, mã khách hàng hoặc ID đã tồn tại";
        public const string ERROR_NOT_FOUND_CUSTOMER= "Không tìm thấy khách hàng với ID hoặc mã khách hàng tương ứng";
        public const string SUCCESS_UPDATE_CUSTOMER = "Cập nhật thành công khách hàng";
        public const string DELETE_SUCCESS = "Xóa thành công khách hàng ";

        /**
         * hợp đồng bảo hiểm*/
        public const string ERROR_ADD_INS = "Thêm thất bại, số hợp đống hoặc ID đã tồn tại";
        public const string ERROR_INVALID_PRODUCT_OR_CUS = "ID sản phẩm hoặc khách hàng hoặc nhân viên không tồn tại trong hệ thống";
        public const string ERROR_NOT_FOUND_INS = "Không tìm thấy hợp đồng bảo hiểm với ID hoặc số hợp đồng tương ứng";
        public const string SUCCESS_UPDATE_INS = "Cập nhật thành công hợp đồng bảo hiểm";
        public const string DEL_SUCCES_INT = "Xóa thành công hợp đồng bảo hiểm ";

        /**
         * Chi nhánh
         */
        public const string ERROR_NOT_FOUND_AG = "Không tồn tại mã chi nhánh trong hệ thống";
        public const string ERROR_ADD_AG = "ID hoặc mã chi nhánh đã tồn tại trong hệ thống";
        public const string DEL_SUCCESS_AG = "Xóa thành công chi nhánh ";
        public const string UPDATE_SUCCESS_AG = "Cập nhật thành công chi nhánh";


        /*
            Nhân viên
         */
        public const string ERROR_NOT_FOUND_EP = "Không tồn tại mã số nhân viên trong hệ thống";
        public const string ERROR_ADD_EP = "ID hoặc mã số nhân viên đã tồn tại trong hệ thống";
        public const string DEL_SUCCESS_EP = "Xóa thành công nhân viên";
        public const string UPDATE_SUCCES_EP = "Cập nhật thành công nhân viên";
    }
}
