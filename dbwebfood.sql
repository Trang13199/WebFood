/*
 Navicat Premium Data Transfer

 Source Server         : newTesst
 Source Server Type    : MySQL
 Source Server Version : 100411
 Source Host           : localhost:3306
 Source Schema         : dbwebfood

 Target Server Type    : MySQL
 Target Server Version : 100411
 File Encoding         : 65001

 Date: 05/09/2020 21:59:40
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for comment
-- ----------------------------
DROP TABLE IF EXISTS `comment`;
CREATE TABLE `comment`  (
  `id_comment` int(11) NOT NULL AUTO_INCREMENT,
  `comment_text` text CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL,
  `id_user` varchar(255) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  `id_product` varchar(255) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  `username` varchar(255) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  PRIMARY KEY (`id_comment`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 5 CHARACTER SET = utf8 COLLATE = utf8_unicode_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of comment
-- ----------------------------
INSERT INTO `comment` VALUES (1, 'hjhzv', '0', '1', 'HoangTrang');
INSERT INTO `comment` VALUES (2, 'hghxkhg', '0', '1', 'TrangHoang');
INSERT INTO `comment` VALUES (4, 'ngon', '0', '100', 'HoangTrang');

-- ----------------------------
-- Table structure for log
-- ----------------------------
DROP TABLE IF EXISTS `log`;
CREATE TABLE `log`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `thongbao` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `capdo` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `taikhoan` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `hanhdong` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `ip` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `ngaythuchien` datetime(0) NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 16 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of log
-- ----------------------------
INSERT INTO `log` VALUES (1, 'success', '0', 'admin', 'them_sp', '127.0.0.1', '2020-09-04 12:35:28');
INSERT INTO `log` VALUES (2, 'success', '0', 'admin', 'them_sp', '127.0.0.1', '2020-09-04 12:37:14');
INSERT INTO `log` VALUES (3, 'success', 'INFO', 'admin', 'them_sp', '127.0.0.1', '2020-09-04 12:42:10');
INSERT INTO `log` VALUES (6, 'success', 'INFO', 'HoangTrang', 'them_sp', '127.0.0.1', '2020-09-04 23:43:13');
INSERT INTO `log` VALUES (7, 'success', 'INFO', 'HoangTrang', 'chinh_sua_sp', '127.0.0.1', '2020-09-04 23:43:43');
INSERT INTO `log` VALUES (8, 'success', 'WARNING', 'HoangTrang', 'xoa_sp', '127.0.0.1', '2020-09-04 23:43:56');
INSERT INTO `log` VALUES (9, 'success', 'INFO', 'HoangTrang', 'them_loai_sp', '127.0.0.1', '2020-09-04 23:58:43');
INSERT INTO `log` VALUES (10, 'success', 'INFO', 'HoangTrang', 'them_loai_sp', '127.0.0.1', '2020-09-05 00:03:03');
INSERT INTO `log` VALUES (11, 'success', 'WARNING', 'HoangTrang', 'xoa_loai_sp', '127.0.0.1', '2020-09-05 00:03:12');
INSERT INTO `log` VALUES (12, 'success', 'WARNING', 'HoangTrang', 'xoa_loai_sp', '127.0.0.1', '2020-09-05 00:03:16');
INSERT INTO `log` VALUES (13, 'success', 'INFO', 'HoangTrang', 'them_sp', '127.0.0.1', '2020-09-05 10:30:48');
INSERT INTO `log` VALUES (14, 'success', 'INFO', 'HoangTrang', 'chinh_sua_sp', '127.0.0.1', '2020-09-05 10:31:01');
INSERT INTO `log` VALUES (15, 'success', 'WARNING', 'HoangTrang', 'xoa_sp', '127.0.0.1', '2020-09-05 10:31:07');

-- ----------------------------
-- Table structure for order
-- ----------------------------
DROP TABLE IF EXISTS `order`;
CREATE TABLE `order`  (
  `id` varchar(255) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `username` varchar(255) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  `phone` varchar(255) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  `email` varchar(255) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  `address` varchar(255) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  `status` varchar(255) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT 'Dang cho van chuyen',
  `date` datetime(0) NULL DEFAULT NULL,
  `total` varchar(255) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  `sumsl` varchar(255) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  `id_user` int(11) NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `id_user`(`id_user`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_unicode_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of order
-- ----------------------------
INSERT INTO `order` VALUES ('02092020030946', 'TrangHoang', '0972635068', 'tranghoang@gmail.com', 'ĐH Nông Lâm, p.Linh Trung, q.Thủ Đức, TP Hồ Chí Minh', 'Đã huỷ', '2020-09-05 09:21:09', '130.000', '5', NULL);
INSERT INTO `order` VALUES ('02192020031947', 'TrangHoang', '0972635068', 'tranghoang@gmail.com', 'ĐH Nông Lâm, p.Linh Trung, q.Thủ Đức, TP Hồ Chí Minh', 'Đã thanh toán', '2020-09-04 02:48:20', '25.000', '1', NULL);
INSERT INTO `order` VALUES ('02282020022829', 'HoangTrang', '0343465347', '17130252@st.hcmuaf.edu.vn', 'Linh Trung, Thủ Đức, TPHCM', 'Thanh toán thành công', '2020-09-04 23:55:24', '130.000', '4', NULL);
INSERT INTO `order` VALUES ('02292020022924', 'HoangTrang', '0343465347', '17130252@st.hcmuaf.edu.vn', 'Linh Trung, Thủ Đức, TPHCM', 'Đã thanh toán', '2020-09-04 02:48:35', '75.000', '4', NULL);
INSERT INTO `order` VALUES ('02322020113204', 'TrangHoang', '0972635068', 'tranghoang@gmail.com', 'ĐH Nông Lâm, p.Linh Trung, q.Thủ Đức, TP Hồ Chí Minh', 'Đã thanh toán', '2020-09-03 00:50:05', '85.000', '3', NULL);
INSERT INTO `order` VALUES ('02382020113819', 'TrangNguyen', '0343465347', '123@gmail.com', 'KTX E, ĐH Nông Lâm, p.Linh Trung, q.Thủ Đức, TP Hồ Chí Minh', 'Dang cho van chuyen', '2020-09-02 11:38:19', '75.000', '3', NULL);
INSERT INTO `order` VALUES ('02392020113929', 'TrangNguyen', '0343465347', '123@gmail.com', 'KTX E, ĐH Nông Lâm, p.Linh Trung, q.Thủ Đức, TP Hồ Chí Minh', 'Đã thanh toán', '2020-09-04 02:48:47', '165.000', '5', NULL);
INSERT INTO `order` VALUES ('02472020104721', 'HoangTrang', '0343465347', '17130252@st.hcmuaf.edu.vn', 'Linh Trung, Thủ Đức, TPHCM', 'Đã thanh toán', '2020-09-04 02:48:57', '55.000', '2', NULL);
INSERT INTO `order` VALUES ('04392020113911', 'HoangTrang', '0343465347', '17130252@st.hcmuaf.edu.vn', 'Linh Trung, Thủ Đức, TPHCM', 'Dang cho van chuyen', '2020-09-04 23:39:11', '60.000', '2', NULL);
INSERT INTO `order` VALUES ('04442020024451', 'HoangTrang', '0343465347', '17130252@st.hcmuaf.edu.vn', 'Linh Trung, Thủ Đức, TPHCM', 'Dang cho van chuyen', '2020-09-04 02:44:52', '155.000', '5', NULL);
INSERT INTO `order` VALUES ('05282020102858', 'HoangTrang', '0343465347', '17130252@st.hcmuaf.edu.vn', 'Linh Trung, Thủ Đức, TPHCM', 'Đã huỷ', '2020-09-05 10:30:02', '60.000', '2', NULL);

-- ----------------------------
-- Table structure for order_detail
-- ----------------------------
DROP TABLE IF EXISTS `order_detail`;
CREATE TABLE `order_detail`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `image` varchar(255) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  `name` varchar(255) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  `quantity` varchar(255) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  `price` varchar(10) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  `id_order` varchar(255) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  `product_id` int(11) NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `id_order`(`id_order`) USING BTREE,
  INDEX `product_id`(`product_id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 29 CHARACTER SET = utf8 COLLATE = utf8_unicode_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of order_detail
-- ----------------------------
INSERT INTO `order_detail` VALUES (1, '/Content/image/hinh4.jpg', 'Gà xốt nước mắm', '1', '35000', '02322020113204', 4);
INSERT INTO `order_detail` VALUES (2, '/Content/image/hinh19.jpg', 'Thịt ba rọi kho hạt sen', '2', '25000', '02322020113204', 19);
INSERT INTO `order_detail` VALUES (3, '/Content/image/hinh95.jpg', 'Bánh canh', '1', '10000', '02382020113819', 95);
INSERT INTO `order_detail` VALUES (4, '/Content/image/hinh53.jpg', 'Mực xào xốt chua ngọt', '1', '35000', '02382020113819', 53);
INSERT INTO `order_detail` VALUES (5, '/Content/image/hinh42.jpg', 'Gỏi cuốn xá xíu thơm lừng', '1', '30000', '02382020113819', 42);
INSERT INTO `order_detail` VALUES (6, '/Content/image/hinh24.jpg', 'Cháo nấm rơm', '2', '30000', '02392020113929', 24);
INSERT INTO `order_detail` VALUES (7, '/Content/image/hinh23.jpg', 'Canh rau ngót nấu mọc', '3', '35000', '02392020113929', 23);
INSERT INTO `order_detail` VALUES (8, '/Content/image/hinh13.jpg', 'Thịt đông', '1', '25000', '02282020022829', 13);
INSERT INTO `order_detail` VALUES (9, '/Content/image/hinh4.jpg', 'Gà xốt nước mắm', '1', '35000', '02282020022829', 4);
INSERT INTO `order_detail` VALUES (10, '/Content/image/hinh97.jpg', 'Cơm chay', '2', '35000', '02282020022829', 97);
INSERT INTO `order_detail` VALUES (11, '/Content/image/hinh11.jpg', 'Kho quẹt', '1', '25000', '02292020022924', 11);
INSERT INTO `order_detail` VALUES (12, '/Content/image/hinh95.jpg', 'Bánh canh', '1', '10000', '02292020022924', 95);
INSERT INTO `order_detail` VALUES (13, '/Content/image/hinh94.jpg', 'Bún đậu nắm tôm', '1', '15000', '02292020022924', 94);
INSERT INTO `order_detail` VALUES (15, '/Content/image/hinh15.jpg', 'Chân gà nướng sả', '1', '25000', '02092020030946', 15);
INSERT INTO `order_detail` VALUES (16, '/Content/image/hinh42.jpg', 'Gỏi cuốn xá xíu thơm lừng', '1', '30000', '02092020030946', 42);
INSERT INTO `order_detail` VALUES (17, '/Content/image/hinh12.jpg', 'Thịt kho trứng', '1', '15000', '02092020030946', 12);
INSERT INTO `order_detail` VALUES (18, '/Content/image/hinh73.jpg', 'Canh khổ qua thập cẩm', '1', '30000', '02092020030946', 73);
INSERT INTO `order_detail` VALUES (19, '/Content/image/hinh72.jpg', 'Sườn xào chua ngọt hai miền Nam Bắc', '1', '30000', '02092020030946', 72);
INSERT INTO `order_detail` VALUES (20, '/Content/image/hinh15.jpg', 'Chân gà nướng sả', '1', '25000', '02192020031947', 15);
INSERT INTO `order_detail` VALUES (21, '/Content/image/hinh1.jpg', 'Sườn kho trứng cút', '1', '25000', '02472020104721', 1);
INSERT INTO `order_detail` VALUES (22, '/Content/image/hinh138.jpg', 'Soup cua', '1', '30000', '02472020104721', 138);
INSERT INTO `order_detail` VALUES (23, '/Content/image/hinh138.jpg', 'Soup cua', '3', '30000', '04442020024451', 138);
INSERT INTO `order_detail` VALUES (24, '/Content/image/hinh105.jpg', 'Tiger', '1', '25000', '04442020024451', 105);
INSERT INTO `order_detail` VALUES (25, '/Content/image/hinh107.jpg', 'Strongbow', '1', '40000', '04442020024451', 107);
INSERT INTO `order_detail` VALUES (26, '/Content/image/hinh113.jpg', 'Cháo ếch', '1', '30000', '04392020113911', 113);
INSERT INTO `order_detail` VALUES (27, '/Content/image/hinh112.jpg', 'Bánh canh chả', '1', '30000', '04392020113911', 112);
INSERT INTO `order_detail` VALUES (28, '/Content/image/hinh100.jpg', 'Cà phê trứng', '2', '30000', '05282020102858', 100);

-- ----------------------------
-- Table structure for product_type
-- ----------------------------
DROP TABLE IF EXISTS `product_type`;
CREATE TABLE `product_type`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  `active` varchar(255) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT '1',
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 4543537 CHARACTER SET = utf8 COLLATE = utf8_unicode_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of product_type
-- ----------------------------
INSERT INTO `product_type` VALUES (1, 'CƠM', '1');
INSERT INTO `product_type` VALUES (2, 'GỎI', '1');
INSERT INTO `product_type` VALUES (3, 'MÓN NƯỚC', '1');
INSERT INTO `product_type` VALUES (4, 'CHÁO', '1');
INSERT INTO `product_type` VALUES (5, 'SOUP', '1');
INSERT INTO `product_type` VALUES (6, 'ĐỒ UỐNG', '1');

-- ----------------------------
-- Table structure for products
-- ----------------------------
DROP TABLE IF EXISTS `products`;
CREATE TABLE `products`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `image` varchar(255) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  `name` varchar(255) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  `content` text CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL,
  `quantity` int(11) NULL DEFAULT NULL,
  `price` double(255, 0) NULL DEFAULT NULL,
  `type` int(11) NULL DEFAULT NULL,
  `active` int(11) NULL DEFAULT 1,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 151 CHARACTER SET = utf8 COLLATE = utf8_unicode_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of products
-- ----------------------------
INSERT INTO `products` VALUES (1, '/Images/files/hinh1.jpg', 'Sườn kho trứng cút', '<p>Sườn non kho trứng c&uacute;t l&agrave; một trong những m&oacute;n ngon bắt cơm nhất. Vị sườn được ninh mềm b&eacute;o b&eacute;o kết hợp với trứng c&uacute;t b&ugrave;i b&ugrave;i th&igrave; c&ograve;n g&igrave; bằng. Ngay b&acirc;y giờ h&atilde;y c&ugrave;ng Pate FOOD thưởng thức m&oacute;n ngon sườn kho trứng c&uacute;t nh&eacute;!&nbsp;</p>\r\n', 9, 25000, 1, 1);
INSERT INTO `products` VALUES (2, '/Content/image/hinh2.jpg', 'Cá bống kho tộ', 'Cá bống kho tộ  đậm vị béo của cá, vị ngọt của nước dừa sẽ làm bạn mê mẩn không thể từ chối.', 0, 35000, 1, 1);
INSERT INTO `products` VALUES (4, '/Content/image/hinh4.jpg', 'Gà xốt nước mắm', 'Món gà xốt nước mắm là món ăn chiếm được lòng yêu mếm của mọi người từ người lớn đến trẻ nhỏ. Nhưng công đoạn và công thức nấu món ngon này không hẳn ai cũng biết. Hãy nhanh tay đặt món và thưởng thức cùng Pate FOOD nhé!', 20, 35000, 1, 1);
INSERT INTO `products` VALUES (5, '/Content/image/hinh5.jpg', 'Cá diêu hồng nấu riêu', 'Canh cá diêu hồng nấu riêu là món ăn đầy dưỡng chất, giúp cho gia đình bạn luôn khỏe mạnh và không cảm giác ngán cơm khi ăn. Vì độ ngọt của cá, vị chua của cà chua tạo nên một hương vị thơm ngon cho bữa ăn thêm tròn vị.', 20, 30000, 1, 1);
INSERT INTO `products` VALUES (7, '/Content/image/hinh7.jpg', 'Vịt kho gừng', 'Thịt vịt béo mềm thấm gia vị đậm đà, kết hợp cùng vị cay nhẹ của tiêu và gừng tươi, ta có món mặn ăn cùng cơm nóng rất ngon. Đặc biệt ăn món này trong những ngày lạnh sẽ có cảm giác rất ấm bụng.', 20, 50000, 1, 1);
INSERT INTO `products` VALUES (8, '/Content/image/hinh8.jpg', 'Ếch xào sả ớt', 'Thịt ếch vừa ngon và giàu chất dinh dưỡng cho cơ thể như protein, đường, chất béo, nhiều loại khoáng chất và canxi. Thịt ếch có thể chế biến nhiều món ăn ngon như cháo ếch Singapore, lẩu ếch, ếch nấu cà ri và tất nhiên không thể thiếu món ếch xào sả ớt.', 20, 25000, 1, 1);
INSERT INTO `products` VALUES (9, '/Content/image/hinh9.jpg', 'Gà rô ti', 'Món khoái khẩu của trẻ thường sẽ là món gà, nhưng cũng chỉ quanh quẩn với món ăn gà rán tại các quán thức ăn nhanh. Gà rô ti là món ăn với vị mới lạ,  vẫn là món gà mà bé thích. Món ăn tưởng chừng rất tạo ra hương vị chuẩn không dễ dàng gì. Nhanh tay đặt ', 20, 25000, 1, 1);
INSERT INTO `products` VALUES (10, '/Content/image/hinh10.jpg', 'Lòng nướng', 'Món nướng thơm ngon nức mũi và khiến cho các tín đồ ăn uống thực sự không thể nào rời mắt đi đâu được . Lòng nướng là một trong những món nướng rất được ưa chuộng. Nhất là vào những ngày trời se se lạnh thế này, vừa hội họp với gia đình hoặc bạn bè, vừa c', 20, 25000, 1, 1);
INSERT INTO `products` VALUES (11, '/Content/image/hinh11.jpg', 'Kho quẹt', 'Với công thức đơn giản: đun thịt ba chỉ ra mỡ; phi thơm hành tím, tỏi, thêm nước mắm Vị Xưa, một chút đường, nước, tôm khô, tiêu sọ và ớt vào. Đảo vài lần rồi giữ lửa riu riu cho nước mắm cô đặc lại thành một hỗn hợp vàng nâu sền sệt. Thêm hành lá và tóp ', 20, 25000, 1, 1);
INSERT INTO `products` VALUES (12, '/Content/image/hinh12.jpg', 'Thịt kho trứng', 'Món Thịt Kho Trứng với miếng thịt mềm hoà quyện cùng ít thớ mỡ, sóng sánh vàng ươm quyện đều với gia vị, điểm thêm vài quả trứng luộc ngấm vị từ lòng trắng đến lòng đỏ, thật ngon không thể cưỡng lại được.', 20, 15000, 1, 1);
INSERT INTO `products` VALUES (13, '/Content/image/hinh13.jpg', 'Thịt đông', 'Thịt đông là một trong những món ăn truyền thống của người Việt, đặc biệt là người miền Bắc trong dịp đông đến, Tết về. Thịt đông có vị hài hoà, hậu thanh mát, lại có mùi thơm đặc trưng của thịt và tiêu sọ, chút sật sật của mộc nhĩ, nấm hương khiến nhiều ', 20, 25000, 1, 1);
INSERT INTO `products` VALUES (14, '/Content/image/hinh14.jpg', 'Ba chỉ chiên trộn nước mắm chua cay', 'Món Ba Chỉ Chiên Trộn Nước Mắm Kiểu Thái cả nhà đều mê tít, nhờ vị thơm nồng của sả, vị chua của chanh quyện với ngọt dịu của nước mắm Vị Xưa, món ba chỉ chiên trộn nước mắm kiểu Thái là gợi ý tuyệt vời cho bữa cơm gia đình nhân những ngày gió lạnh đấy! ', 20, 30000, 1, 1);
INSERT INTO `products` VALUES (15, '/Content/image/hinh15.jpg', 'Chân gà nướng sả', 'Chân Gà Nướng Sả là món ăn luôn được các chàng và các nàng ưa chuộng vì độ ngon và không gây ngấy, có thể ăn lai rai rất tuyệt. Tuy nhiên, vấn đề vệ sinh thực phẩm là vấn đề đáng lo ngại khi ăn món Chân Gà Nướng ở các hàng ăn bên ngoài. Barona chia sẻ với', 20, 25000, 1, 1);
INSERT INTO `products` VALUES (16, '/Content/image/hinh16.jpg', 'Bò kho', 'Bò kho là món ăn truyền thống, rất quen thuộc trong ẩm thực Việt Nam. Bò kho luôn là ứng viên hàng đầu được lựa chọn trong danh sách các món ngon bữa tiệc.', 20, 30000, 3, 1);
INSERT INTO `products` VALUES (17, '/Content/image/hinh17.jpg', 'Vịt kho măng', 'Món ngon mỗi ngày đậm đà thấm vị vào những miếng thịt vịt ngọt ngon béo ngậy hòa cùng chút thanh đạm của măng tươi như thấm phần chất béo vào trong măng làm cho người dùng cảm giác thật thú vị khi thưởng thức.', 20, 30000, 1, 1);
INSERT INTO `products` VALUES (18, '/Content/image/hinh18.jpg', 'Cá thu rim nước dừa', 'Nước dừa ngoài công dụng để làm nước giải khát trong những ngày hè oi bức còn được dùng để làm nguyên liệu chế biến nhiều món ăn ngon khác nhau như thịt kho nước dừa, cá sốt nước dừa, hay cá kho nước dừa…Cá thu rim nước dừa xiêm có thể xem là sự kết hợp t', 20, 40000, 1, 1);
INSERT INTO `products` VALUES (19, '/Content/image/hinh19.jpg', 'Thịt ba rọi kho hạt sen', 'Món thịt kho là món ăn hàng ngày rất quen thuộc với nhiều gia đình. Tuy nhiên thịt kho hạt sen thì không phải gia đình nào cũng từng chế biến và thưởng thức. Hãy nhanh tay đặt món và thưởng thức cùng  Pate FOOD nhé!', 20, 25000, 1, 1);
INSERT INTO `products` VALUES (20, '/Content/image/hinh20.jpg', 'Ốc xào sả ớt', 'Ốc xào sả ớt không chỉ là món ăn đường phố hấp dẫn mà trong các bữa cơm gia đình, món ăn ấm bụng này cũng xuất hiện rất thường xuyên. Với những nguyên liệu đơn giản, bạn có thể tự tay chế biến món ốc xào sả ớt ngon tuyệt cho gia đình mà không cần phải ra ', 20, 20000, 1, 1);
INSERT INTO `products` VALUES (21, '/Content/image/hinh21.jpg', 'Ngêu hấp', 'Nghêu hấp xả là món ăn chơi cuốn hút không biết bao nhiêu tín đồ ẩm thực Việt bằng vị ngọt của nghêu kết hợp với mùi thơm nồng của sả, gừng, vị cay cay của ớt và chua chua của me. Rất thích hợp để làm món ăn vặt cho cả gia đình ngày cuối tuần.', 20, 20000, 1, 1);
INSERT INTO `products` VALUES (22, '/Content/image/hinh22.jpg', 'Cá thu Nhật sốt cà', 'Cá sốt cà là món ăn dân dã, quen thuộc trong bữa cơm mỗi gia đình Việt Nam hàng ngày. Có rất nhiều loại cá sốt cà, nhưng mỗi món lại có 1 bí kíp làm khác nhau. Bạn hãy nhanh tay đặt món và cùng Pate FOOD thưởng thức nhé!', 20, 45000, 1, 1);
INSERT INTO `products` VALUES (23, '/Content/image/hinh23.jpg', 'Canh rau ngót nấu mọc', 'Có lẽ các bạn thường quen thuộc với món canh rau ngót thịt băm hay canh rau ngót nấu sườn… Hôm bay, Pate FOOD xin mang đến cho bạn món canh rau ngót với mọc lạ miệng cho bữa cơm ngày cuối tuần thêm hấp dẫn nhé.', 20, 35000, 1, 1);
INSERT INTO `products` VALUES (24, '/Content/image/hinh24.jpg', 'Cháo nấm rơm', 'Cháo nấm rơm là món ăn hàng ngày cực kỳ bổ dưỡng bởi nấm chứa nhiều nguyên tố vi lượng và vitamin rất tốt cho tim mạch, hệ bài tiết và chống lão hóa.', 20, 30000, 4, 1);
INSERT INTO `products` VALUES (25, '/Content/image/hinh25.jpg', 'Cua sốt chua ngọt', 'Món cua sốt chua ngọt có vị ngọt của thịt cua kết hợp với nước sốt chua chua, cay cay tạo nên món ăn thơm ngon, hấp dẫn cho bữa ăn hàng ngày.', 20, 30000, 1, 1);
INSERT INTO `products` VALUES (26, '/Content/image/hinh26.jpg', 'Chả cá lã vọng', 'Với những ai đã từng đến Thủ đô, hẳn sẽ không thể bỏ qua cơ hội thưởng thức Chả cá Lã Vọng- một trong những món ăn đặc trưng của nét ẩm thực Hà thành. Sự mềm mịn của miếng thịt cá cùng mùi rau thơm lừng và cách chế biến cầu kì đã đem lại sự nổi tiếng cho ', 20, 35000, 1, 1);
INSERT INTO `products` VALUES (27, '/Content/image/hinh27.jpg', 'Canh rong biển đậu hũ', 'Canh rong biển là món ăn bổ máu, tốt cho tim, thận, hệ tuần hoàn, hệ bài tiết, rong biển là loại thức ăn thường được dùng phối hợp trong thực đơn cho những người béo phì, người mắc bệnh tiểu đường, người cao huyết áp.  Món canh đậu hũ rong biển có vị ngọt', 20, 35000, 1, 1);
INSERT INTO `products` VALUES (28, '/Content/image/hinh28.jpg', 'Canh củ sen hầm sườn non', 'Vào những ngày Hè oi bức, Canh củ sen hầm sườn non với nước dùng ngọt vị thịt, củ sen dẻo mềm, những thứ nguyên liệu chứa đầy chất dinh dưỡng sẽ là món ăn vừa thanh mát, vừa tốt cho sức khỏe, rất thích hợp cho gia đình bạn. Bên cạnh đó, canh củ sen còn là', 20, 25000, 1, 1);
INSERT INTO `products` VALUES (29, '/Content/image/hinh29.jpg', 'Canh cua rau đay', '“Canh cua rau đay” đã trở thành món ăn dân dã của người Việt Nam, đặc biệt trong những ngày hè, món canh này được mọi người yêu thích bởi ngon miệng, bổ dưỡng và thanh mát.', 20, 20000, 1, 1);
INSERT INTO `products` VALUES (30, '/Content/image/hinh30.jpg', 'Bò kho gừng', 'Thịt bò là một nguyên liệu rất giàu dinh dưỡng cho bữa ăn gia đình. Có rất nhiều cách để chế biến những món ăn hấp dẫn từ nguyên liệu này, trong đó món Bò kho gừng rất được ưa chuộng. Thịt bò mềm với phần thịt nạm, vị đậm đà, cay thơm, nóng hổi, rất thích', 20, 20000, 1, 1);
INSERT INTO `products` VALUES (31, '/Content/image/hinh31.jpg', 'Cơm tấm sườn', 'Cuối tuần, bạn có thể tự tay làm món cơm tấm sườn nướng hấp dẫn với nhiều màu sắc và thơm lừng cho cả nhà thưởng thức', 20, 35000, 1, 1);
INSERT INTO `products` VALUES (32, '/Content/image/hinh32.jpg', 'Cơm cháy kho quẹt', 'Cơm cháy kho quẹt và rau quả luộc có thể xem là “bộ ba ăn ý”, chỉ cần thưởng thức một lần bạn sẽ nhớ mãi. Với thành phần cực kỳ đơn giản và bạn có thể nấu ăn hàng ngày', 20, 35000, 1, 1);
INSERT INTO `products` VALUES (33, '/Content/image/hinh33.jpg', 'Mắm kho quẹt', 'Mắm kho quẹt là món ăn dân dã của người miền Nam, trước đây được xem là món ăn ít tiền của người nghèo, nhưng ngày nay kho quẹt đã được sử dụng rất nhiều trong những nhà hàng quán ăn cao cấp do hương vị mặn mà hấp dẫn khi được chấm cùng các loại rau củ lu', 20, 25000, 1, 1);
INSERT INTO `products` VALUES (34, '/Content/image/hinh34.jpg', 'Tôm chiên nước mắm', 'Với lớp vỏ giòn tan, bên trong là vị ngọt của tôm, thêm độ đậm đà của nước mắm Phú Quốc, chút cay cay của ớt và mùi thơm của hành phi hòa quyện khiến món tôm chiên nước mắm hấp dẫn đến lạ.', 20, 25000, 1, 1);
INSERT INTO `products` VALUES (35, '/Content/image/hinh35.jpg', 'Bắp bò ngâm nước mắm tuyệt hảo', 'Không cần nấu nướng nhưng vẫn có được bữa ăn ngon, bạn tin không? Bắp bò ngâm nước mắm truyền thống sẽ luôn là món ăn được lựa chọn hàng đầu cho những ngày Tết. Đặc biệt khi bạn không có quá nhiều thời gian để nấu nướng thì chỉ cần cắt lát miếng bắp bò ng', 20, 20000, 1, 1);
INSERT INTO `products` VALUES (36, '/Content/image/hinh36.jpg', 'Cá cơm tẩm chiên giòn', 'Cá cơm có thể chế biến nhiều món ăn hấp dẫn cho bữa cơm gia đình, nhưng một món ăn từ cá cơm mà hầu như mọi người đều cảm thấy rất hấp dẫn đó là món cá cơm tẩm bột chiên giòn, với vị bùi của cá cơm, được chiên thật giòn chấm với nước mắm chua ngọt thì quả', 20, 25000, 1, 1);
INSERT INTO `products` VALUES (37, '/Content/image/hinh37.jpg', 'Thịt ba rọi rim trứng cút', 'Món thịt ba rọi rim trứng cút với thịt mềm, phần bì dai và trứng thấm gia vị cho bữa cơm gia đình thêm phong phú và bổ dưỡng.', 20, 35000, 1, 1);
INSERT INTO `products` VALUES (38, '/Content/image/hinh38.jpg', 'Chả cá nhồi ớt rim gừng', 'Món chả cá nhồi ớt sẽ rất phù hợp với bữa cơm gia đình trong những ngày trời mưa rét. Vị cay cay tê tê nơi đầu lưỡi sẽ mang đến sự ấm áp, vị ngọt của cá sẽ mang đến cảm giác bình dị, dân dã và thân quen. Chắc chắn tất cả các thành viên trong gia đình sẽ r', 20, 25000, 1, 1);
INSERT INTO `products` VALUES (39, '/Content/image/hinh39.jpg', 'Cá nục rim thơm', 'Mỗi khi thưởng thức món cá nục rim thơm thì chúng ta lại có cảm giác như đang ở quê nhà', 20, 10000, 1, 1);
INSERT INTO `products` VALUES (40, '/Content/image/hinh40.jpg', 'Vịt ram gừng cực ngon và lạ miệng', 'Những món ăn từ thịt vịt được rất nhiều người ưa chuộng vì hương vị đặc biệt, không bị ngấy và lành tính. Có rất nhiều cách chế biến thịt vịt như vịt kho gừng sả, vịt nấu chao, gỏi vịt…nhưng món thịt vịt ram gừng là món ăn có sự kết hợp hài hòa giữa 2 ngu', 20, 25000, 1, 1);
INSERT INTO `products` VALUES (41, '/Content/image/hinh41.jpg', 'Cá cơm rim tiêu', 'Món cá cơm có vị đậm đà, giòn, cay và thơm mùi của xốt gia vị hoàn chỉnh sẽ làm món mặn này thêm ngon, lạ miệng.', 20, 35000, 1, 1);
INSERT INTO `products` VALUES (42, '/Content/image/hinh42.jpg', 'Gỏi cuốn xá xíu thơm lừng', 'Rau sống giòn tươi kết hợp với vị đậm đà của miếng thịt xá xíu đem đến cho bạn cảm giác thú vị khi thưởng thức', 20, 30000, 1, 1);
INSERT INTO `products` VALUES (43, '/Content/image/hinh43.jpg', 'Mì xào rau cải và sường non xốt xá xíu', 'Hương vị thịt nướng xá xíu đậm đà trong từng thớ thịt hòa quyện cùng với sợi mì xào dai dai, rau củ tươi ngon sẽ đem đến cho gia đình bạn món Mì xào thơm ngon không thể chối từ.', 20, 25000, 1, 1);
INSERT INTO `products` VALUES (44, '/Content/image/hinh44.jpg', 'Tôm chiên xốt xá xíu', 'Tôm chiên giòn rụm lại đậm đà, quyện hương thơm của xốt gia vị hoàn chỉnh thịt nướng xá xíu, chút ngọt của rau củ ăn kèm, sẽ đem đến cho bạn cảm giác ngon miệng, ấn tượng khó quên', 20, 50000, 1, 1);
INSERT INTO `products` VALUES (45, '/Content/image/hinh45.jpg', 'Cơm chiên gà nướng xá xíu', 'Món gà nướng xá xíu được tẩm ướp đầy đủ hương vị tạo nên màu sắc thịt gà đỏ nâu nổi bậc màu cùng đặc trưng của xá xí sau khi được nướng chín tới thơm nức và nóng hổi. Gà nướng xá xíu rất thích hợp làm món ăn ngon cho các bữa tiệc cuối tuần trong gia đình.', 20, 35000, 1, 1);
INSERT INTO `products` VALUES (46, '/Content/image/hinh46.jpg', 'Bánh ướt cuốn thịt nướng sả', 'Bánh ướt thịt nướng là một món ăn hấp dẫn của người dân xứ Huế nói riêng và người dân miền Trung nói chung. Nếu bạn đã từng được thưởng thức món bánh ướt thịt nướng này chắc chắn bạn sẽ mê mẩn với những món ăn đó.', 20, 40000, 1, 1);
INSERT INTO `products` VALUES (47, '/Content/image/hinh47.jpg', 'Cá nướng sả bọc giấy bạc', 'Với cá nướng giấy bạc, bạn không lo món ăn bị cháy, nhiệt độ được giữ nóng mà còn giúp phần sốt được thấm dần vào cá trong khi nướng, hơn nữa tiện lợi không mất quá nhiều thời gian vệ sinh sau khi nướng.', 20, 40000, 1, 1);
INSERT INTO `products` VALUES (48, '/Content/image/hinh48.jpg', 'Nấm rơm bọc thịt nướng sả', 'Với hương vị quen thuộc nhưng mới lạ trong cách chế biến, nấm rơm bọc thịt nướng sả sẽ là món ăn khiến các thành viên trong gia đình vô cùng ngạc nhiên & thích thú vì mùi vị thơm ngon, lạ miệng và đặc biệt cân bằng dinh dưỡng giữa động vật và thực vật tốt', 20, 60000, 1, 1);
INSERT INTO `products` VALUES (49, '/Content/image/hinh49.jpg', 'Chả đùm hải sản nướng sả', 'Chả đùm hải sản là món ăn ngon và hấp dẫn, hãy trổ tài để mang đến một bữa cơm thật ngon cho gia đình bạn.', 20, 25000, 1, 1);
INSERT INTO `products` VALUES (50, '/Content/image/hinh50.jpg', 'Bò nướng sả cuộn lá lốt', 'Thịt bò được ướp với sả kết hợp với các loại gia vị, cuộn trong lá lốt rồi đem nướng trên bếp than hồng. Thịt bò mềm, béo hòa quyện hương sả và lá lốt thơm lừng, hấp dẫn không thể chối từ. ', 20, 35000, 1, 1);
INSERT INTO `products` VALUES (51, '/Content/image/hinh51.jpg', 'Cá nướng ngũ vị', 'Cá nướng là món ăn hấp dẫn, thơm ngon, vị ngọt. Sau khi thưởng thức, hương vị của nó như vẫn lưu giữ nơi đầu lưỡi.', 20, 30000, 1, 1);
INSERT INTO `products` VALUES (52, '/Content/image/hinh52.jpg', 'Cá chiên xốt chua ngọt', 'Với thịt cá được chiên giòn giòn thơm ngon lại có thêm nước sốt chua chua ngọt ngọt rưới lên trên khiến cá có thêm hương vị hấp dẫn, tránh cảm giác ngán khi ăn đồ chiên rán lại còn trở nên ngon miệng hơn, tuyệt vời hơn.', 20, 40000, 1, 1);
INSERT INTO `products` VALUES (53, '/Content/image/hinh53.jpg', 'Mực xào xốt chua ngọt', 'Mực xào chua ngọt chắc chắn sẽ làm bữa cơm chiều thêm phần lạ miệng và hấp dẫn', 20, 35000, 1, 1);
INSERT INTO `products` VALUES (54, '/Content/image/hinh54.jpg', 'Tôm xốt thơm chua ngọt', 'Món ăn sẽ chinh phục bạn ngay từ cái nhìn đầu tiên với hương vị lôi cuốn, màu sắc bắt mắt', 20, 20000, 1, 1);
INSERT INTO `products` VALUES (55, '/Content/image/hinh55.jpg', 'Ngêu xào rau quế chua ngọt', 'Món ăn có vị cay của ớt, mùi thơm hấp dẫn của lá quế và vị ngọt dịu đặc trưng của nghêu tươi, chỉ ít phút chuẩn bị bạn sẽ có món ăn ngon này', 20, 30000, 1, 1);
INSERT INTO `products` VALUES (56, '/Content/image/hinh56.jpg', 'Mực dồn thịt xốt chua ngọt', 'Được quây quần bên gia đình thưởng thức món mực xốt chua ngọt ngon miệng đậm đà sẽ là món ăn đặc biệt cho ngày mát trời', 20, 20000, 1, 1);
INSERT INTO `products` VALUES (57, '/Content/image/hinh57.jpg', 'Hoành thánh chiên giòn xốt chua ngọt', 'Hoành thánh giòn giòn, hòa quyện với nước xốt chua ngọt sẽ đem đến cho bạn cảm giác vừa lạ lẫm, vừa thân thuộc sẽ để lại trong bạn một ấn tượng khó quên', 20, 25000, 1, 1);
INSERT INTO `products` VALUES (58, '/Content/image/hinh58.jpg', 'Sườn heo nướng xốt chua ngọt', 'Món Sườn heo nướng xốt chua ngọt lạ miệng với vị chua chua, ngọt ngọt hòa quyện với miếng sườn thơm mềm sẽ làm cho cho bữa ăn trở nên thật thú vị.', 20, 25000, 1, 1);
INSERT INTO `products` VALUES (59, '/Content/image/hinh59.jpg', 'Rau củ chiên xốt chua  ngọt', 'Thơm thơm, giòn giòn, ngọt ngọt từ rau củ, lại không hề gây ngán, đó là ưu điểm của món ăn này', 20, 25000, 1, 1);
INSERT INTO `products` VALUES (60, '/Content/image/hinh60.jpg', 'Thịt ba chỉ kho rau củ', 'Những miếng thịt vàng ươm, beo béo và thơm lừng hương vị đặc trưng với món này chắc chắn sẽ khiến những người thân ăn ngon miệng hơn', 20, 25000, 1, 1);
INSERT INTO `products` VALUES (61, '/Content/image/hinh61.jpg', 'Thịt kho trứng quế hồi', 'Một chút biến tấu với chút quế, hồi sẽ làm bữa cơm thêm phần ấm cúng và ngon đến bất ngờ !!!', 20, 40000, 1, 1);
INSERT INTO `products` VALUES (62, '/Content/image/hinh62.jpg', 'Cá điêu hồng kho tiêu xanh', 'Cắn một miếng cá, bạn sẽ cảm nhận vị thơm mềm và ngọt của cá hòa quyện vị đậm đà của xốt gia vị hoàn chỉnh cá/thịt kho, thơm nồng của tiêu xanh, miếng cá trở nên hấp dẫn hơn bao giờ hết', 20, 25000, 1, 1);
INSERT INTO `products` VALUES (63, '/Content/image/hinh63.jpg', 'Cá nục kho thơm', 'Cá kho là món ăn có mặt thường xuyên trong các bữa cơm của gia đình Việt với rất đa dạng các công thức kho cá. Ăn cơm nóng cùng món cá kho đậm đà thì không còn gì bằng.Cá nục mềm, béo hòa quyện với vị chua ngọt của thơm, sẽ tạo nên hương vị khó cưỡng', 20, 25000, 1, 1);
INSERT INTO `products` VALUES (64, '/Content/image/hinh64.jpg', 'Giò heo nấu chua cay', 'Món giò heo nấu chua thơm ngon sẽ thích hợp với bữa cơm chiều của gia đình bạn', 20, 35000, 1, 1);
INSERT INTO `products` VALUES (65, '/Content/image/hinh65.jpg', 'Canh chả cá nấu chua', 'Món canh chua biến tấu thay cá bằng chả cá sẽ đem đến cho bạn hương vị lạ mà ngon.', 20, 70000, 1, 1);
INSERT INTO `products` VALUES (66, '/Content/image/hinh66.jpg', 'Thịt kho tiêu', 'Thịt kho tiêu là một trong những món ăn dân dã và đơn giản nhưng không bao giờ giảm đi sức hấp dẫn của nó trong các bữa ăn hàng ngày. Thịt heo hòa quyện ít thớ mỡ, thơm ngon, béo ngậy cùng với nước xốt sền sệt và tiêu hột cay cay mang lại hương vị thật đậ', 20, 25000, 1, 1);
INSERT INTO `products` VALUES (67, '/Content/image/hinh67.jpg', 'Thịt nướng sả', 'Thịt nướng ướp sả thơm nức mũi bởi vị thơm đặc trưng của sả, vị ngọt dai của thịt, món này mà ăn kèm với bún và rau sống thì ngon hết sảy.', 20, 25000, 1, 1);
INSERT INTO `products` VALUES (68, '/Content/image/hinh68.jpg', 'Lẩu thập cẩm', 'Với những ngày mùa đông giá rét như thế này thì món lẩu luôn được ưu tiên hàng đầu bởi vị thơm ngon, hấp dẫn từ nhiều loại thực phẩm, nóng sốt và ngọt lừ. Không chỉ thế mà món lẩu còn mang thêm hơi ấm gia đình bạn bè khi tất cả cùng quây quần bên nồi lẩu ', 20, 25000, 1, 1);
INSERT INTO `products` VALUES (69, '/Content/image/hinh69.jpg', 'Thịt ram', 'Nước xốt thấm đều vào từng thớ thịt khi ram tạo nên màu vàng óng thật đẹp mắt và miếng thịt thơm mềm đều vị.', 20, 25000, 1, 1);
INSERT INTO `products` VALUES (70, '/Content/image/hinh70.jpg', 'Canh chua cá lóc', 'Canh chua cá lóc là một món ăn quen thuộc của người dân Việt Nam đặc biệt là ở vùng miền tây Nam Bộ. Canh chua cá không những thơm ngon mà còn cung cấp nhiều dinh dưỡng cho cơ thể. Hơn thế, món canh chua cũng có thể dễ dàng chế biến từ các loại cá khác nh', 20, 25000, 1, 1);
INSERT INTO `products` VALUES (71, '/Content/image/hinh71.jpg', 'Hải sản xào chua ngọt', 'Vị chua ngọt từ cà chua của nước xốt hòa cùng hải sản tươi ngon cho món ăn tuyệt vời không cưỡng lại được', 20, 30000, 1, 1);
INSERT INTO `products` VALUES (72, '/Content/image/hinh72.jpg', 'Sườn xào chua ngọt hai miền Nam Bắc', 'Nói đến các món chua ngọt chắc hẳn ai cũng biết đến món sườn xào chua ngọt, đây là món khoái khẩu của rất nhiều người. Những miếng sườn được chiên vàng đều khi ăn vị béo của sườn hòa quyện với vị chua, ngọt, cay của các loại gia vị mang lại cảm cảm giác t', 20, 30000, 1, 1);
INSERT INTO `products` VALUES (73, '/Content/image/hinh73.jpg', 'Canh khổ qua thập cẩm', 'Cũng là khổ qua nhồi thông thường, nhưng để đổi vị, chúng ta sẽ làm theo một công thức khác, không nhồi khổ qua với thịt đơn thuần mà nên kết hợp với những nguyên liệu thiên nhiên để món canh có tác dụng giải nhiệt hơn', 20, 30000, 1, 1);
INSERT INTO `products` VALUES (74, '/Content/image/hinh74.jpg', 'Tôm thịt rim mặm', 'Dù chỉ là một món bình dân quen thuộc với mỗi gia đình Việt Nam, món tôm thịt vẫn có giá trị riêng, mang vị mặn ngọt hài hòa giữa tôm và thịt, màu sắc hấp dẫn, ăn kèm với cơm trắng rất ngon.', 20, 35000, 1, 1);
INSERT INTO `products` VALUES (75, '/Content/image/hinh75.jpg', 'Ếch kho tộ', 'Thịt ếch được coi là món ăn rất bổ dưỡng với các thành phần dinh dưỡng phong phú như protein, chất béo, canxi, phốt pho, kali, vitamin A, B, D, E, canxi…., cung cấp đủ dinh dưỡng cho cơ thể, giúp ăn ngon, ngủ ngon, đặc biệt giúp các trẻ suy dinh dưỡng tăn', 20, 35000, 1, 1);
INSERT INTO `products` VALUES (76, '/Content/image/hinh76.jpg', 'Cá kèo kho rau răm, hành khô', 'Nồi cá kèo kho rau răm thơm nức mũi, thịt cá mềm nhưng vẫn rất săn chắc, không bị bở mặc dù kho lâu. Hương vị đậm đà, có chút cay của tiêu và ớt, mùi rau răm ngập tràn rất hấp dẫn. Món cá kèo rau răm dùng với cơm trắng rất ngon, thịt cá ngọt, rau răm thơm', 20, 60000, 1, 1);
INSERT INTO `products` VALUES (77, '/Content/image/hinh77.jpg', 'Canh tôm khô rau dền, mồng tơi', 'Trưa hè oi bức, được bát canh rau dền nấu tôm thanh mát, ngọt lành vô cùng đưa cơm, thật là món canh lý tưởng cho bữa cơm trưa hè.', 20, 30000, 1, 1);
INSERT INTO `products` VALUES (79, '/Content/image/hinh79.jpg', 'Chả cá', 'Chả cá là một món đặc biệt của thủ đô Hà Nội, miếng cá nóng hổi được tẩm ướp với tỏi, gừng, nghệ và thì là trên một cái chảo nóng đã gắng bó với bao nhiêu thế hệ người Hà Nội', 20, 30000, 1, 1);
INSERT INTO `products` VALUES (81, '/Content/image/hinh81.jpg', 'Cao lầu', 'Món mì thịt lợn từ Hội An này hơi giống với các nền văn hóa khác nhau đã ghé thăm cảng buôn bán tại thủ đô của nó. Sợi mì dày hơn tương tự như udon của Nhật Bản, bánh quy giòn và thịt lợn giòn là một nét Trung Quốc, trong khi nước dùng và thảo mộc rõ ràng', 20, 30000, 1, 1);
INSERT INTO `products` VALUES (82, '/Content/image/hinh82.jpg', 'Gỏi cuốn', 'Những chiếc nem tươi nhẹ và tốt cho sức khỏe này là một lựa chọn tuyệt vời khi bạn đã thưởng thức quá nhiều thực phẩm chiên ở Việt Nam. Các bưu kiện mờ đầu tiên được đóng gói với rau xà lách, một lát thịt hoặc hải sản và một lớp rau mùi, trước khi được cu', 20, 70000, 1, 1);
INSERT INTO `products` VALUES (83, '/Content/image/hinh83.jpg', 'Bánh khét', 'Biến thể đẹp mắt này của một chiếc bánh kếp Việt Nam có tất cả các thành phần ngon giống nhau nhưng kích thước nhỏ hơn. Lớp ngoài giòn được làm bằng nước cốt dừa và phần nhân thường bao gồm tôm, đậu xanh và hành lá với một lớp vỏ tôm khô phủ lên trên.', 20, 15000, 1, 1);
INSERT INTO `products` VALUES (84, '/Content/image/hinh84.jpg', 'Bún bò Nam bộ', 'Những lát thịt bò mềm trộn với đậu phộng giòn và giá đỗ, và có hương vị của các loại thảo mộc tươi, hẹ khô giòn, và một giọt nước mắm và ớt cay.', 20, 25000, 1, 1);
INSERT INTO `products` VALUES (85, '/Content/image/hinh85.jpg', 'Gà nướng', 'KFC có thể ở khắp mọi nơi tại Việt Nam những ngày này, nhưng hãy bỏ qua món ăn nhanh này. Pate FOOD mang đến cho người dùng món gà nướng hết sức dân dã. Mật ong ướp sau đó nướng trên thịt nướng lửa lớn, chân gà, cánh và chân được phục vụ mềm mại khác thườ', 20, 15000, 1, 1);
INSERT INTO `products` VALUES (88, '/Content/image/hinh88.jpg', 'Bột chiên', 'Món ăn vặt yêu thích trên đường phố Sài Gòn, bột chiên, nổi tiếng với cả trường ngoài giờ và đám đông sau nửa đêm. Những miếng bột gạo được chiên trong chảo lớn cho đến khi giòn và sau đó một quả trứng được trộn vào hỗn hợp. Sau khi nấu xong, nó được phục', 20, 30000, 1, 1);
INSERT INTO `products` VALUES (91, '/Content/image/hinh91.jpg', 'Nem chạy / chả giò', 'Lớp vỏ giòn với rau củ mềm và thịt được nhúng trong nước sốt sền sệt  trước khi thưởng thức món chính. Ở phía bắc, chúng được gọi là nem chạy trong khi người miền nam gọi chúng là cha gio.', 20, 30000, 1, 1);
INSERT INTO `products` VALUES (92, '/Content/image/hinh92.jpg', 'Bún bò Huế', 'Món ăn có nguyên liệu chính là bún, thịt bắp bò, giò heo, cùng nước dùng có màu đỏ đặc trưng và vị sả và ruốc. Đôi khi tô bún còn được thêm vào thịt bò tái, chả cua, và các loại nguyên liệu khác.Trong nước dùng của bún, người Huế thường nêm vào một ít mắm', 20, 25000, 3, 1);
INSERT INTO `products` VALUES (93, '/Content/image/hinh93.jpg', 'Nộm hoa chuối', 'Hoa chuối (cục tím dày mà sau này sẽ biến thành chùm chuối) được gọt vỏ và cắt lát mỏng sau đó trộn với đu đủ xanh, cà rốt, và rau mùi cùng với thịt gà và rót nước sốt mặn giòn và đậu phộng giòn.', 20, 30000, 2, 1);
INSERT INTO `products` VALUES (94, '/Content/image/hinh94.jpg', 'Bún đậu nắm tôm', 'Món đậu phụ cùng bún trông đơn giản này được ăn kèm với mắm tôm. Nước chấm màu tím cay được sử dụng để tạo hương vị cho các miếng đậu phụ chiên giòn là cốt lõi của bữa ăn.', 20, 15000, 1, 1);
INSERT INTO `products` VALUES (95, '/Content/image/hinh95.jpg', 'Bánh canh', 'Bánh canh bao gồm nước dùng được nấu từ tôm, cá và giò heo thêm gia vị tùy theo từng loại bánh canh. Sợi bánh canh có thể được làm từ bột gạo, bột mì, bột năng hoặc bột sắn hoặc bột gạo pha bột sắn. Bánh được làm từ bột được cán thành tấm và cắt ra thành ', 20, 10000, 3, 1);
INSERT INTO `products` VALUES (96, '/Content/image/hinh96.jpg', 'Bò bít Tết', 'Món sườn nướng mỏng thường được ăn kèm với trứng, nêm khoai tây dày và thịt viên Việt Nam trên một đĩa gang nóng hổi.', 20, 25000, 1, 1);
INSERT INTO `products` VALUES (97, '/Content/image/hinh97.jpg', 'Cơm chay', 'Một phần cơm ở Thanh Lương có giá từ 10.000 đồng đến 20.000đồng với nhiều thức ăn, kèm một chén canh, chất lượng đầy đủ mùi vị đậm đà.', 20, 35000, 1, 1);
INSERT INTO `products` VALUES (98, '/Content/image/hinh98.jpg', 'Chè', 'Món tráng miệng này có thể được phục vụ trong một cái bát hoặc ly. Bạn được tùy chọn thêm các lớp thạch đậu, nước cốt dừa, trái cây và đá. Một ly chè mát lạnh có thể xua tan mùa hè oi bức', 20, 30000, 1, 1);
INSERT INTO `products` VALUES (99, '/Content/image/hinh99.jpg', 'Đậu phụ sốt cà chua', 'Đậu phụ hay còn gọi là đậu hũ sốt cà chua không những thơm ngon, hấp dẫn  về hương vị mà còn thanh mát, nhẹ nhàng, dễ ăn và không bị ngán', 20, 30000, 1, 1);
INSERT INTO `products` VALUES (100, '/Content/image/hinh100.jpg', 'Cà phê trứng', 'Lớp trứng được làm cực kì ngon, bông xốp, mịn, có vị béo ngậy, để lâu cũng không bị tanh, tuy vậy thì hơi ngọt so với cà phê trứng chính gốc Hà Nội, nhưng vì thế mà hợp khẩu vị dân Sài Gòn hơn. Bù lại, phần cà phê đen rất đậm đà, thơm lừng mùi cà phê rang', 20, 30000, 6, 1);
INSERT INTO `products` VALUES (101, '/Content/image/hinh101.jpg', 'Nước ép ổi', 'Ổi chứa rất nhiều vitami tốt cho hệ tiêu hóa và làm đẹp da. Uống nước ép ổi thường xuyên cũng giúp giảm cân hiệu quả.', 20, 20000, 6, 1);
INSERT INTO `products` VALUES (102, '/Content/image/hinh102.jpg', 'Nước ép táo', 'Trái táo nổi tiếng là loại trái cây chứa nhiều chất dinh dưỡng. Lượng vitamin C trong táo sẽ đốt cháy lượng mỡ thừa trong cơ thể. Ngoài ra, trong táo còn chứa 1 lượng polyphenol đáng kể rất tốt cho sức khỏe. ', 20, 20000, 6, 1);
INSERT INTO `products` VALUES (103, '/Content/image/hinh103.jpg', 'Nước cam', 'Một ly nước cam cung cấp 75 kcal và hơn 50% nhu cầu trong ngày về vitamin C cho 1 người. Flavonoid có trong nước cam kết hợp với vitamin C, giúp tăng cường hệ miễn dịch và bảo vệ mao mạch.', 20, 20000, 6, 1);
INSERT INTO `products` VALUES (104, '/Content/image/hinh104.jpg', 'Coca Cola', 'Sản phẩm không chỉ giúp giải tỏa cơn khát trong những ngày nóng nực mà còn cung cấp nguồn năng lượng cùng hàm lượng khoáng chất dồi dào, cho bạn khơi lại hứng khởi. Nước Giải Khát Có Gas Coca-Cola với lượng gas lớn sẽ giúp bạn xua tan mọi cảm giác mệt mỏi', 20, 20000, 6, 1);
INSERT INTO `products` VALUES (105, '/Content/image/hinh105.jpg', 'Tiger', 'Bia Tiger được lên men tự nhiên từ hoa bia và lúa mạch thượng hạng nhập khẩu từ Châu Âu tạo nên một loại bia với hương vị và chất lượng tuyệt hảo. Bia Tiger sẽ mang đến cho bạn những trải nghiệm khó quên, để cuộc vui càng thêm vui.  ', 20, 25000, 6, 1);
INSERT INTO `products` VALUES (106, '/Content/image/hinh106.jpg', 'Bia sài gòn', 'Hương vị độc đáo của bia Sài Gòn là kết tinh sản vật của vùng đất phương Nam trù phú và tinh thần hào sảng phóng khoáng của người Sài Gòn, trở một phần không thể thiếu trong cuộc sống vui buồn hàng ngày. Bia Sài Gòn đang chiếm giữ vị trí dẫn đầu trong ngà', 20, 50000, 6, 1);
INSERT INTO `products` VALUES (107, '/Content/image/hinh107.jpg', 'Strongbow', 'Là loại thức uống có nguồn gốc từ châu Âu và đã phổ biến toàn cầu với cách thức chế biến đầy ấn tượng từ quá trình lên men táo tự nhiên mang đến men say thuần khiết, hài hòa và đầy cuốn hút', 20, 40000, 6, 1);
INSERT INTO `products` VALUES (108, '/Content/image/hinh108.jpg', 'Heineken', 'Món ngon mỗi ngày đậm đà thấm vị ngọt ngon béo ngậy hòa cùng chút thanh đạm của măng tươi như thấm phần chất béo làm cho người dùng cảm giác thật thú vị khi thưởng thức.', 15, 30000, 6, 1);
INSERT INTO `products` VALUES (109, '/Content/image/hinh109.jpg', 'Cà phê sữa', 'Là loại thức uống có nguồn gốc từ châu Âu và đã phổ biến toàn cầu với cách thức chế biến đầy ấn tượng từ quá trình lên men táo tự nhiên mang đến men say thuần khiết, hài hòa và đầy cuốn hút', 20, 20000, 6, 1);
INSERT INTO `products` VALUES (110, '/Content/image/hinh110.jpg', 'Nước suối', 'Là loại thức uống có nguồn gốc từ châu Âu và đã phổ biến toàn cầu với cách thức chế biến đầy ấn tượng từ quá trình lên men táo tự nhiên mang đến men say thuần khiết, hài hòa và đầy cuốn hút', 20, 10000, 6, 1);
INSERT INTO `products` VALUES (111, '/Content/image/hinh111.png', 'Bánh canh cá', 'Món ngon mỗi ngày đậm đà thấm vị ngọt ngon béo ngậy hòa cùng chút thanh đạm của măng tươi như thấm phần chất béo làm cho người dùng cảm giác thật thú vị khi thưởng thức.', 20, 30000, 3, 1);
INSERT INTO `products` VALUES (112, '/Content/image/hinh112.jpg', 'Bánh canh chả', 'Món ngon mỗi ngày đậm đà thấm vị ngọt ngon béo ngậy hòa cùng chút thanh đạm của măng tươi như thấm phần chất béo làm cho người dùng cảm giác thật thú vị khi thưởng thức.', 25, 30000, 3, 1);
INSERT INTO `products` VALUES (113, '/Content/image/hinh113.jpg', 'Cháo ếch', 'Món ngon mỗi ngày đậm đà thấm vị ngọt ngon béo ngậy hòa cùng chút thanh đạm của măng tươi như thấm phần chất béo làm cho người dùng cảm giác thật thú vị khi thưởng thức.', 25, 30000, 4, 1);
INSERT INTO `products` VALUES (114, '/Content/image/hinh114.jpg', 'Cháo gà', 'Món ngon mỗi ngày đậm đà thấm vị ngọt ngon béo ngậy hòa cùng chút thanh đạm của măng tươi như thấm phần chất béo làm cho người dùng cảm giác thật thú vị khi thưởng thức.', 25, 30000, 4, 1);
INSERT INTO `products` VALUES (115, '/Content/image/hinh115.jpg', 'Cháo hải sản', 'Món ngon mỗi ngày đậm đà thấm vị ngọt ngon béo ngậy hòa cùng chút thanh đạm của măng tươi như thấm phần chất béo làm cho người dùng cảm giác thật thú vị khi thưởng thức.', 52, 30000, 4, 1);
INSERT INTO `products` VALUES (116, '/Content/image/hinh116.jpg', 'Cháo lòng ', 'Món ngon mỗi ngày đậm đà thấm vị ngọt ngon béo ngậy hòa cùng chút thanh đạm của măng tươi như thấm phần chất béo làm cho người dùng cảm giác thật thú vị khi thưởng thức.', 25, 30000, 4, 1);
INSERT INTO `products` VALUES (117, '/Content/image/hinh117.jpeg', 'Cháo thịt bằm', 'Món ngon mỗi ngày đậm đà thấm vị ngọt ngon béo ngậy hòa cùng chút thanh đạm của măng tươi như thấm phần chất béo làm cho người dùng cảm giác thật thú vị khi thưởng thức.', 25, 30000, 4, 1);
INSERT INTO `products` VALUES (118, '/Content/image/hinh118.jpg', 'Hủ tiếu bò kho', 'Món ngon mỗi ngày đậm đà thấm vị ngọt ngon béo ngậy hòa cùng chút thanh đạm của măng tươi như thấm phần chất béo làm cho người dùng cảm giác thật thú vị khi thưởng thức.', 25, 30000, 3, 1);
INSERT INTO `products` VALUES (119, '/Content/image/hinh119.jpg', 'Cháo đậu xanh', 'Món ngon mỗi ngày đậm đà thấm vị ngọt ngon béo ngậy hòa cùng chút thanh đạm của măng tươi như thấm phần chất béo làm cho người dùng cảm giác thật thú vị khi thưởng thức.', 35, 30000, 4, 1);
INSERT INTO `products` VALUES (120, '/Content/image/hinh120.jpg', 'Gỏi tôm ngó sen', 'Món ngon mỗi ngày đậm đà thấm vị ngọt ngon béo ngậy hòa cùng chút thanh đạm của măng tươi như thấm phần chất béo làm cho người dùng cảm giác thật thú vị khi thưởng thức.', 30, 30000, 2, 1);
INSERT INTO `products` VALUES (121, '/Content/image/hinh121.jpg', 'Gỏi tai heo', 'Món ngon mỗi ngày đậm đà thấm vị ngọt ngon béo ngậy hòa cùng chút thanh đạm của măng tươi như thấm phần chất béo làm cho người dùng cảm giác thật thú vị khi thưởng thức.', 30, 30000, 2, 1);
INSERT INTO `products` VALUES (122, '/Content/image/hinh122.jpg', 'Gỏi xoài cá sặc', 'Món ngon mỗi ngày đậm đà thấm vị ngọt ngon béo ngậy hòa cùng chút thanh đạm của măng tươi như thấm phần chất béo làm cho người dùng cảm giác thật thú vị khi thưởng thức.', 30, 30000, 2, 1);
INSERT INTO `products` VALUES (123, '/Content/image/hinh123.jpg', 'Gỏi bưởi', 'Món ngon mỗi ngày đậm đà thấm vị ngọt ngon béo ngậy hòa cùng chút thanh đạm của măng tươi như thấm phần chất béo làm cho người dùng cảm giác thật thú vị khi thưởng thức.', 30, 30000, 2, 1);
INSERT INTO `products` VALUES (124, '/Content/image/hinh124.jpg', 'Gỏi tôm mực', 'Món ngon mỗi ngày đậm đà thấm vị ngọt ngon béo ngậy hòa cùng chút thanh đạm của măng tươi như thấm phần chất béo làm cho người dùng cảm giác thật thú vị khi thưởng thức.', 30, 30000, 2, 1);
INSERT INTO `products` VALUES (125, '/Content/image/hinh125.jpg', 'Gỏi gà', 'Món ngon mỗi ngày đậm đà thấm vị ngọt ngon béo ngậy hòa cùng chút thanh đạm của măng tươi như thấm phần chất béo làm cho người dùng cảm giác thật thú vị khi thưởng thức.', 30, 30000, 2, 1);
INSERT INTO `products` VALUES (126, '/Content/image/hinh126.jpg', 'Gỏi bò', 'Món ngon mỗi ngày đậm đà thấm vị ngọt ngon béo ngậy hòa cùng chút thanh đạm của măng tươi như thấm phần chất béo làm cho người dùng cảm giác thật thú vị khi thưởng thức.', 30, 30000, 2, 1);
INSERT INTO `products` VALUES (127, '/Content/image/hinh127.jpg', 'Phở gà', 'Món ngon mỗi ngày đậm đà thấm vị ngọt ngon béo ngậy hòa cùng chút thanh đạm của măng tươi như thấm phần chất béo làm cho người dùng cảm giác thật thú vị khi thưởng thức.', 30, 30000, 3, 1);
INSERT INTO `products` VALUES (128, '/Content/image/hinh128.jpg', 'Pepsi', 'Là loại thức uống có nguồn gốc từ châu Âu và đã phổ biến toàn cầu với cách thức chế biến đầy ấn tượng từ quá trình lên men táo tự nhiên mang đến men say thuần khiết, hài hòa và đầy cuốn hút', 30, 30000, 6, 1);
INSERT INTO `products` VALUES (129, '/Content/image/hinh129.jpg', 'Cơm tấm', 'Món ngon mỗi ngày đậm đà thấm vị ngọt ngon béo ngậy hòa cùng chút thanh đạm của măng tươi như thấm phần chất béo làm cho người dùng cảm giác thật thú vị khi thưởng thức.', 30, 30000, 1, 1);
INSERT INTO `products` VALUES (130, '/Content/image/hinh130.jpg', 'Cơm chiên gà', 'Món ngon mỗi ngày đậm đà thấm vị ngọt ngon béo ngậy hòa cùng chút thanh đạm của măng tươi như thấm phần chất béo làm cho người dùng cảm giác thật thú vị khi thưởng thức.', 30, 30000, 1, 1);
INSERT INTO `products` VALUES (131, '/Content/image/hinh131.jpg', 'Cơm cá', 'Món ngon mỗi ngày đậm đà thấm vị ngọt ngon béo ngậy hòa cùng chút thanh đạm của măng tươi như thấm phần chất béo làm cho người dùng cảm giác thật thú vị khi thưởng thức.', 30, 30000, 1, 1);
INSERT INTO `products` VALUES (132, '/Content/image/hinh132.jpg', 'Cơm chiên trứng', 'Món ngon mỗi ngày đậm đà thấm vị ngọt ngon béo ngậy hòa cùng chút thanh đạm của măng tươi như thấm phần chất béo làm cho người dùng cảm giác thật thú vị khi thưởng thức.', 30, 30000, 1, 1);
INSERT INTO `products` VALUES (133, '/Content/image/hinh133.jpg', 'Cơm chiên hải sản', 'Món ngon mỗi ngày đậm đà thấm vị ngọt ngon béo ngậy hòa cùng chút thanh đạm của măng tươi như thấm phần chất béo làm cho người dùng cảm giác thật thú vị khi thưởng thức.', 30, 30000, 1, 1);
INSERT INTO `products` VALUES (134, '/Content/image/hinh134.jpg', 'Cơm gà', 'Món ngon mỗi ngày đậm đà thấm vị ngọt ngon béo ngậy hòa cùng chút thanh đạm của măng tươi như thấm phần chất béo làm cho người dùng cảm giác thật thú vị khi thưởng thức.', 30, 30000, 1, 1);
INSERT INTO `products` VALUES (135, '/Content/image/hinh135.jpg', 'Cơm sườn trứng', 'Món ngon mỗi ngày đậm đà thấm vị ngọt ngon béo ngậy hòa cùng chút thanh đạm của măng tươi như thấm phần chất béo làm cho người dùng cảm giác thật thú vị khi thưởng thức.', 30, 30000, 1, 1);
INSERT INTO `products` VALUES (136, '/Content/image/hinh136.jpg', 'Cơm xíu mại', 'Món ngon mỗi ngày đậm đà thấm vị ngọt ngon béo ngậy hòa cùng chút thanh đạm của măng tươi như thấm phần chất béo làm cho người dùng cảm giác thật thú vị khi thưởng thức.', 30, 30000, 1, 1);
INSERT INTO `products` VALUES (137, '/Content/image/hinh137.jpg', 'Cơm thịt kho trứng', 'Món ngon mỗi ngày đậm đà thấm vị ngọt ngon béo ngậy hòa cùng chút thanh đạm của măng tươi như thấm phần chất béo làm cho người dùng cảm giác thật thú vị khi thưởng thức.', 30, 30000, 1, 1);
INSERT INTO `products` VALUES (138, '/Content/image/hinh138.jpg', 'Soup cua', 'Món ngon mỗi ngày đậm đà thấm vị ngọt ngon béo ngậy hòa cùng chút thanh đạm của măng tươi như thấm phần chất béo làm cho người dùng cảm giác thật thú vị khi thưởng thức.', 30, 30000, 5, 1);
INSERT INTO `products` VALUES (139, '/Content/image/hinh139.jpg', 'Soup nấm đông cô', 'Món ngon mỗi ngày đậm đà thấm vị ngọt ngon béo ngậy hòa cùng chút thanh đạm của măng tươi như thấm phần chất béo làm cho người dùng cảm giác thật thú vị khi thưởng thức.', 30, 30000, 5, 1);
INSERT INTO `products` VALUES (140, '/Content/image/hinh140.jpg', 'Soup chay', 'Món ngon mỗi ngày đậm đà thấm vị ngọt ngon béo ngậy hòa cùng chút thanh đạm của măng tươi như thấm phần chất béo làm cho người dùng cảm giác thật thú vị khi thưởng thức.', 30, 33000, 5, 1);
INSERT INTO `products` VALUES (141, '/Content/image/hinh141.jpg', 'Soup óc heo', 'Món ngon mỗi ngày đậm đà thấm vị ngọt ngon béo ngậy hòa cùng chút thanh đạm của măng tươi như thấm phần chất béo làm cho người dùng cảm giác thật thú vị khi thưởng thức.', 30, 30000, 5, 1);

-- ----------------------------
-- Table structure for resource
-- ----------------------------
DROP TABLE IF EXISTS `resource`;
CREATE TABLE `resource`  (
  `id` int(10) NOT NULL AUTO_INCREMENT,
  `control` varchar(255) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  `action` varchar(255) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  `active` varchar(255) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 15 CHARACTER SET = utf8 COLLATE = utf8_unicode_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of resource
-- ----------------------------
INSERT INTO `resource` VALUES (1, 'Admin', 'them_sp', '1');
INSERT INTO `resource` VALUES (2, 'Admin', 'chinh_sua_sp', '1');
INSERT INTO `resource` VALUES (3, 'Admin', 'xoa_sp', '1');
INSERT INTO `resource` VALUES (4, 'admin', 'chinh_sua_donhang', '1');
INSERT INTO `resource` VALUES (5, 'admin', 'them_khach_hang', '1');
INSERT INTO `resource` VALUES (6, 'admin', 'chinh_sua_kh', '1');
INSERT INTO `resource` VALUES (7, 'admin', 'xoa_kh', '1');
INSERT INTO `resource` VALUES (8, 'admin', 'them_loai_sp', '1');
INSERT INTO `resource` VALUES (9, 'admin', 'chinh_sua_loaiSP', '1');
INSERT INTO `resource` VALUES (10, 'admin', 'xoa_loai_sp', '1');
INSERT INTO `resource` VALUES (11, 'admin', 'del_oder', '1');

-- ----------------------------
-- Table structure for role
-- ----------------------------
DROP TABLE IF EXISTS `role`;
CREATE TABLE `role`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `username` varchar(255) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  `actionName` varchar(255) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  `level` int(10) NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 18 CHARACTER SET = utf8 COLLATE = utf8_unicode_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of role
-- ----------------------------
INSERT INTO `role` VALUES (1, 'HoangTrang', 'them_sp', 0);
INSERT INTO `role` VALUES (2, 'HoangTrang', 'chinh_sua_sp', 0);
INSERT INTO `role` VALUES (3, 'HoangTrang', 'xoa_sp', 0);
INSERT INTO `role` VALUES (4, 'HoangTrang', 'chinh_sua_donhang', 0);
INSERT INTO `role` VALUES (5, 'HoangTrang', 'them_khach_hang', 0);
INSERT INTO `role` VALUES (6, 'HoangTrang', 'chinh_sua_kh', 0);
INSERT INTO `role` VALUES (7, 'HoangTrang', 'xoa_kh', 0);
INSERT INTO `role` VALUES (8, 'HoangTrang', 'them_loai_sp', 0);
INSERT INTO `role` VALUES (9, 'HoangTrang', 'chinh_sua_loaiSP', 0);
INSERT INTO `role` VALUES (10, 'HoangTrang', 'xoa_loai_sp', 0);
INSERT INTO `role` VALUES (11, 'HoangTrang', 'del_oder', 0);
INSERT INTO `role` VALUES (12, 'TrangNguyen', 'them_sp', 0);
INSERT INTO `role` VALUES (13, 'HoangTrang', 'chinh_sua_sp', 0);
INSERT INTO `role` VALUES (17, 'TrangNguyen', 'chinh_sua_sp', 0);

-- ----------------------------
-- Table structure for user
-- ----------------------------
DROP TABLE IF EXISTS `user`;
CREATE TABLE `user`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `username` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `password` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `email` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `phone` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `address` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `gender` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `level` int(11) NULL DEFAULT 1,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `username`(`username`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 4 CHARACTER SET = utf8 COLLATE = utf8_unicode_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of user
-- ----------------------------
INSERT INTO `user` VALUES (1, 'TrangHoang', '80582dab029dba8f0d2cd380d7daa234', 'tranghoang@gmail.com', '0972635068', 'ĐH Nông Lâm, p.Linh Trung, q.Thủ Đức, TP Hồ Chí Minh', 'Nam', 1);
INSERT INTO `user` VALUES (2, 'TrangNguyen', '2fac62e79c1581cf2c6eb2fff69c74e9', '123@gmail.com', '0343465347', 'KTX E, ĐH Nông Lâm, p.Linh Trung, q.Thủ Đức, TP Hồ Chí Minh', 'Nữ', 0);
INSERT INTO `user` VALUES (3, 'HoangTrang', '4d73a62ffa26dce065268ec9a181f351', '17130252@st.hcmuaf.edu.vn', '0343465347', 'Linh Trung, Thủ Đức, TPHCM', 'Nam', 0);

SET FOREIGN_KEY_CHECKS = 1;
