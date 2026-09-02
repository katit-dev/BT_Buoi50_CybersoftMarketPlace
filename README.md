\# CybersoftMarketPlace - Buổi 49 Profile Module



\## Overview



Hoàn thành chức năng Profile cho dự án CybersoftMarketPlace (.NET 10 + Blazor).



Các chức năng đã thực hiện:



\- Update Profile

\- Update Avatar

\- Change Password

\- Logout

\- Route protection

\- Order History





\---



\# Features Completed





\## 1. Update Profile



Cho phép người dùng cập nhật:



\- Full Name

\- Phone

\- Address





API:





Screenshot:



!\[Update Profile](screenshots/buoi49\_updateProfile.png)







\---



\## 2. Update Avatar



Cho phép cập nhật ảnh đại diện bằng Avatar URL.





API:





Screenshot:



!\[Update Avatar](screenshots/buoi49\_updateAvatar.png)







\---



\## 3. Change Password



Người dùng có thể đổi mật khẩu.



Kiểm tra:



\- Password cũ

\- Password mới

\- Confirm Password





API:





Screenshot:



!\[Change Password](screenshots/buoi49\_ChangePassword.png)







\---



\## 4. Logout \& Authentication Protection



Logout thực hiện:



\- Xóa JWT Token trong LocalStorage

\- Clear User State

\- Navigate về Login





Kiểm tra:



\- Sau khi logout truy cập `/profile`

\- User bị redirect về `/login`





Screenshot:



!\[Logout](screenshots/buoi49\_Logout.png)







\---



\## 5. Order History



Lấy danh sách đơn hàng của user đang đăng nhập.



UserId được lấy từ JWT Token, không nhận từ client.





API:





Xử lý EF Core:



\- Include()

\- ThenInclude()

\- AsNoTracking()



Tránh lỗi N+1 Query.





Screenshot:



!\[My Orders](screenshots/buoi49\_GetMyOrders.png)







