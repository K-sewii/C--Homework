namespace BaiThucHanhLINQ
{
    // ==========================================
    // CHƯƠNG TRÌNH CHÍNH
    // ==========================================
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; // Hỗ trợ in tiếng Việt

            Console.WriteLine("================ BÀI 2.1 ================");
            Bai21();

            Console.WriteLine("\n================ BÀI 2.2 ================");
            Bai22();

            Console.WriteLine("\n================ BÀI 3.1 ================");
            Bai31();

            Console.WriteLine("\n================ BÀI 3.2 ================");
            Bai32();

            Console.WriteLine("\n================ BÀI 5.1 ================");
            Bai51();

            Console.WriteLine("\n================ BÀI 5.2 ================");
            Bai52();

            Console.WriteLine("\n================ BÀI 6.2 ================");
            Bai62();

            Console.ReadLine();
        }

        // ==========================================
        // BÀI 2.1. TRUY VẤN MẢNG SỐ NGUYÊN
        // ==========================================
        static void Bai21()
        {
            int[] mangSo = { 50, 42, 16, 3, 9, 8, 12, 7, 24, 0 };

            // a. Liệt kê các phần tử chia hết cho 4 và 3 (Method Syntax)
            var cauA = mangSo.Where(x => x % 4 == 0 && x % 3 == 0);
            Console.WriteLine("a. Các phần tử chia hết cho 4 và 3: " + string.Join(", ", cauA));

            // b. Liệt kê các phần tử nhỏ hơn hoặc bằng 3 (Query Syntax)
            var cauB = from x in mangSo
                       where x <= 3
                       select x;
            Console.WriteLine("b. Các phần tử nhỏ hơn hoặc bằng 3: " + string.Join(", ", cauB));

            // c. Tạo một dãy mới: số chẵn chia đôi, số lẻ giữ nguyên (Method Syntax)
            var cauC = mangSo.Select(x => x % 2 == 0 ? x / 2 : x);
            Console.WriteLine("c. Dãy mới: " + string.Join(", ", cauC));
        }

        // ==========================================
        // BÀI 2.2. TRUY VẤN MẢNG CHUỖI
        // ==========================================
        static void Bai22()
        {
            string[] mangChuoi = { "đầu", "lòng", "hai", "ả", "tố", "nga", "Thúy", "Kiều", "là", "chị", "em", "là", "Thúy", "Vân" };

            // a. Liệt kê các phần tử có 4 ký tự và sắp xếp tăng dần theo ký tự đầu tiên
            var cauA = mangChuoi.Where(s => s.Length == 4).OrderBy(s => s[0]);
            Console.WriteLine("a. Các phần tử 4 ký tự sắp xếp tăng dần theo ký tự đầu: " + string.Join(", ", cauA));

            // b. Biến đổi mỗi phần tử thành dạng: <chữ thường> - <CHỮ HOA>
            var cauB = mangChuoi.Select(s => $"{s.ToLower()} - {s.ToUpper()}");
            Console.WriteLine("b. Biến đổi định dạng:");
            foreach (var item in cauB) Console.WriteLine("   " + item);

            // c. Liệt kê các phần tử có chứa ký tự "u"
            var cauC = mangChuoi.Where(s => s.Contains("u"));
            Console.WriteLine("c. Các phần tử chứa ký tự 'u': " + string.Join(", ", cauC));

            // d. Liệt kê các từ "Thúy Kiều Thúy Vân" bằng cách chọn các phần tử bắt đầu bằng chữ in hoa
            var cauD = mangChuoi.Where(s => !string.IsNullOrEmpty(s) && char.IsUpper(s[0]));
            Console.WriteLine("d. Các từ bắt đầu bằng chữ in hoa: " + string.Join(" ", cauD));
        }

        // ==========================================
        // BÀI 3.1. THỐNG KÊ MẢNG SỐ
        // ==========================================
        static void Bai31()
        {
            int[] mangSo = { 50, 42, 12, 3, 9, 8, 1, 50, 3, 42, 85 };

            // a. Cho biết tổng số phần tử, số phần tử chẵn và số phần tử lẻ
            Console.WriteLine($"a. Tổng số phần tử: {mangSo.Count()}");
            Console.WriteLine($"   Số phần tử chẵn: {mangSo.Count(x => x % 2 == 0)}");
            Console.WriteLine($"   Số phần tử lẻ: {mangSo.Count(x => x % 2 != 0)}");

            // b. Tính tổng các giá trị, giá trị lớn nhất và giá trị nhỏ nhất
            Console.WriteLine($"b. Tổng: {mangSo.Sum()}, Max: {mangSo.Max()}, Min: {mangSo.Min()}");

            // c. Cho biết có bao nhiêu giá trị khác nhau trong mảng
            Console.WriteLine($"c. Số giá trị khác nhau: {mangSo.Distinct().Count()}");

            // d. Phân nhóm các phần tử theo số dư khi chia cho 5
            var cauD = mangSo.GroupBy(x => x % 5).OrderBy(g => g.Key);
            Console.WriteLine("d. Phân nhóm theo số dư khi chia cho 5:");
            foreach (var group in cauD)
            {
                Console.WriteLine($"   Số dư {group.Key}: {string.Join(", ", group)}");
            }
        }

        // ==========================================
        // BÀI 3.2. THỐNG KÊ MẢNG CHUỖI
        // ==========================================
        static void Bai32()
        {
            string[] monAn = { "Bún bò Huế", "Hủ tiếu heo", "Bánh canh", "Bánh mì", "Nước Cà phê", "Mì quảng", "Cơm tấm", "Nước Chanh dây", "Mì xào", "Bún riêu", "Bánh cuốn", "Mì gói", "Bún chả", "Hủ tiếu Nam vang" };

            // a. Tìm các phần tử có chiều dài ngắn nhất và dài nhất
            int minLen = monAn.Min(s => s.Length);
            int maxLen = monAn.Max(s => s.Length);
            Console.WriteLine("a. Các món có chiều dài ngắn nhất: " + string.Join(", ", monAn.Where(s => s.Length == minLen)));
            Console.WriteLine("   Các món có chiều dài dài nhất: " + string.Join(", ", monAn.Where(s => s.Length == maxLen)));

            // b. Phân nhóm theo từ đầu tiên của tên món và liệt kê các phần tử trong từng nhóm
            var cauB = monAn.GroupBy(s => s.Split(' ')[0]);
            Console.WriteLine("b. Phân nhóm theo từ đầu tiên:");
            foreach (var group in cauB)
            {
                Console.WriteLine($"   Nhóm '{group.Key}': {string.Join(", ", group)}");
            }

            // c. Đếm số phần tử có từ đầu tiên là "Bánh"
            Console.WriteLine($"c. Số món có từ đầu tiên là 'Bánh': {monAn.Count(s => s.StartsWith("Bánh"))}");
        }

        // ==========================================
        // BÀI 5.1. TRUY VẤN CƠ BẢN TRÊN LIST<MONHOC>
        // ==========================================
        static void Bai51()
        {
            var dsMon = DuLieu.DS_Mon();

            // a. Liệt kê tên các môn học bắt đầu bằng "Lập trình"
            var cauA = dsMon.Where(m => m.TenMon.StartsWith("Lập trình")).Select(m => m.TenMon);
            Console.WriteLine("a. Môn học bắt đầu bằng 'Lập trình': " + string.Join(", ", cauA));

            // b. Liệt kê các môn thuộc hệ "CD", sắp xếp số tiết giảm dần rồi mã môn tăng dần
            var cauB = dsMon.Where(m => m.He == "CD")
                            .OrderByDescending(m => m.SoTiet)
                            .ThenBy(m => m.MaMon);
            Console.WriteLine("b. Môn hệ CD (Số tiết giảm dần, Mã môn tăng dần):");
            foreach (var m in cauB) Console.WriteLine($"   {m.MaMon} - {m.TenMon} - {m.SoTiet} tiết");

            // c. Liệt kê các môn có tên chứa từ "web", chỉ lấy Tên môn và Hệ
            var cauC = dsMon.Where(m => m.TenMon.ToLower().Contains("web"))
                            .Select(m => new { m.TenMon, m.He });
            Console.WriteLine("c. Môn có tên chứa 'web':");
            foreach (var m in cauC) Console.WriteLine($"   {m.TenMon} (Hệ: {m.He})");

            // d. Liệt kê các môn thuộc hệ "KTV", sắp xếp tăng dần theo Mã môn
            var cauD = dsMon.Where(m => m.He == "KTV").OrderBy(m => m.MaMon);
            Console.WriteLine("d. Môn hệ KTV (Mã môn tăng dần):");
            foreach (var m in cauD) Console.WriteLine($"   {m.MaMon} - {m.TenMon}");
        }

        // ==========================================
        // BÀI 5.2. THỐNG KÊ TRÊN LIST<MONHOC>
        // ==========================================
        static void Bai52()
        {
            var dsMon = DuLieu.DS_Mon();

            // a. Cho biết tổng số môn hiện có
            Console.WriteLine($"a. Tổng số môn: {dsMon.Count}");

            // b. Đếm số môn có tên bắt đầu bằng "Lập trình"
            Console.WriteLine($"b. Số môn bắt đầu bằng 'Lập trình': {dsMon.Count(m => m.TenMon.StartsWith("Lập trình"))}");

            // c. Tính tổng số tiết của hệ Kỹ thuật viên (KTV)
            Console.WriteLine($"c. Tổng số tiết hệ KTV: {dsMon.Where(m => m.He == "KTV").Sum(m => m.SoTiet)}");

            // d. Cho biết tổng số môn của mỗi hệ: Hệ, Tổng số môn
            var cauD = dsMon.GroupBy(m => m.He).Select(g => new { He = g.Key, TongSoMon = g.Count() });
            Console.WriteLine("d. Tổng số môn của mỗi hệ:");
            foreach (var item in cauD) Console.WriteLine($"   Hệ {item.He}: {item.TongSoMon} môn");

            // e. Nhóm theo Số tiết; in Số tiết và Tổng số môn, sắp xếp giảm dần theo Số tiết
            var cauE = dsMon.GroupBy(m => m.SoTiet)
                            .Select(g => new { SoTiet = g.Key, TongSoMon = g.Count() })
                            .OrderByDescending(x => x.SoTiet);
            Console.WriteLine("e. Nhóm theo Số tiết (giảm dần):");
            foreach (var item in cauE) Console.WriteLine($"   {item.SoTiet} tiết: {item.TongSoMon} môn");

            // f. Cho biết thông tin môn học có số tiết cao nhất
            byte maxTiet = dsMon.Max(m => m.SoTiet);
            var cauF = dsMon.Where(m => m.SoTiet == maxTiet);
            Console.WriteLine("f. Môn học có số tiết cao nhất:");
            foreach (var m in cauF) Console.WriteLine($"   {m.MaMon} - {m.TenMon} - {m.SoTiet} tiết");

            // g. Thống kê theo Hệ: tổng số môn, tổng số tiết, số tiết cao nhất, số tiết thấp nhất
            var cauG = dsMon.GroupBy(m => m.He).Select(g => new
            {
                He = g.Key,
                TongMon = g.Count(),
                TongTiet = g.Sum(m => m.SoTiet),
                MaxTiet = g.Max(m => m.SoTiet),
                MinTiet = g.Min(m => m.SoTiet)
            });
            Console.WriteLine("g. Thống kê theo Hệ:");
            foreach (var item in cauG)
                Console.WriteLine($"   Hệ {item.He}: {item.TongMon} môn, Tổng {item.TongTiet} tiết, Max {item.MaxTiet}, Min {item.MinTiet}");

            // h. Liệt kê các môn học được phân nhóm theo Hệ
            Console.WriteLine("h. Liệt kê môn học phân nhóm theo Hệ:");
            var cauH = dsMon.GroupBy(m => m.He);
            foreach (var group in cauH)
            {
                Console.WriteLine($"   Hệ {group.Key}:");
                foreach (var m in group) Console.WriteLine($"      {m.MaMon} - {m.TenMon}");
            }

            // i. Liệt kê các môn học được phân nhóm theo Số tiết và tăng dần theo Số tiết
            Console.WriteLine("i. Liệt kê môn học phân nhóm theo Số tiết (tăng dần):");
            var cauI = dsMon.OrderBy(m => m.SoTiet).GroupBy(m => m.SoTiet);
            foreach (var group in cauI)
            {
                Console.WriteLine($"   {group.Key} tiết:");
                foreach (var m in group) Console.WriteLine($"      {m.MaMon} - {m.TenMon}");
            }

            // j. Với hệ KTV, phân nhóm theo học phần HP2, HP3, HP4, HP5; sắp xếp theo Mã môn
            Console.WriteLine("j. Hệ KTV phân nhóm theo học phần (HP2, HP3, HP4, HP5):");
            var cauJ = dsMon.Where(m => m.He == "KTV")
                            .GroupBy(m => m.MaMon.Substring(0, 3)) // Lấy 3 ký tự đầu: HP2, HP3...
                            .OrderBy(g => g.Key);
            foreach (var group in cauJ)
            {
                Console.WriteLine($"   Học phần {group.Key}:");
                foreach (var m in group.OrderBy(x => x.MaMon)) Console.WriteLine($"      {m.MaMon} - {m.TenMon}");
            }

            // k. Phân nhóm theo Hệ, chỉ lấy các môn có Số tiết > 40; trong mỗi nhóm sắp xếp theo Mã môn
            Console.WriteLine("k. Phân nhóm theo Hệ (Số tiết > 40, sắp xếp theo Mã môn):");
            var cauK = dsMon.Where(m => m.SoTiet > 40)
                            .GroupBy(m => m.He);
            foreach (var group in cauK)
            {
                Console.WriteLine($"   Hệ {group.Key}:");
                foreach (var m in group.OrderBy(x => x.MaMon)) Console.WriteLine($"      {m.MaMon} - {m.TenMon} - {m.SoTiet} tiết");
            }
        }

        // ==========================================
        // BÀI 6.2. JOIN VÀ CÁC TOÁN TỬ TẬP HỢP
        // ==========================================
        static void Bai62()
        {
            var dsMon = DuLieu.DS_Mon();
            var dsHe = DuLieu.DS_He();

            // a. Dùng join để liệt kê: Tên hệ, Mã môn, Tên môn
            var cauA = from h in dsHe
                       join m in dsMon on h.MaHe equals m.He
                       select new { h.TenHe, m.MaMon, m.TenMon };
            Console.WriteLine("a. Join Hệ và Môn:");
            foreach (var item in cauA) Console.WriteLine($"   {item.TenHe} - {item.MaMon} - {item.TenMon}");

            // b. Liệt kê cả những hệ chưa có môn học (Left Outer Join với GroupJoin + DefaultIfEmpty)
            var cauB = from h in dsHe
                       join m in dsMon on h.MaHe equals m.He into g
                       from m in g.DefaultIfEmpty()
                       select new { h.TenHe, MaMon = m?.MaMon ?? "Chưa có", TenMon = m?.TenMon ?? "Chưa có" };
            Console.WriteLine("b. Left Join (Hệ chưa có môn):");
            foreach (var item in cauB) Console.WriteLine($"   {item.TenHe} - {item.MaMon} - {item.TenMon}");

            // c. Liệt kê cả hệ chưa có môn học và môn học chưa khai báo hệ (Full Outer Join)
            var leftJoin = from h in dsHe
                           join m in dsMon on h.MaHe equals m.He into g
                           from m in g.DefaultIfEmpty()
                           select new { TenHe = h.TenHe, MaMon = m?.MaMon, TenMon = m?.TenMon, He = m?.He };

            var rightJoin = from m in dsMon
                            join h in dsHe on m.He equals h.MaHe into g
                            from h in g.DefaultIfEmpty()
                            select new { TenHe = h?.TenHe ?? "Chưa khai báo", MaMon = m.MaMon, TenMon = m.TenMon, He = m.He };

            var cauC = leftJoin.Union(rightJoin).Distinct();
            Console.WriteLine("c. Full Outer Join (Hệ chưa có môn + Môn chưa khai báo hệ):");
            foreach (var item in cauC) Console.WriteLine($"   Hệ: {item.TenHe} | Môn: {item.MaMon} - {item.TenMon}");

            // d. Chỉ liệt kê những hệ chưa có môn học và những môn học chưa khai báo hệ
            var cauD = cauC.Where(x => x.TenHe == "Chưa khai báo" || x.MaMon == null);
            Console.WriteLine("d. Chỉ lấy Hệ chưa có môn và Môn chưa khai báo hệ:");
            foreach (var item in cauD) Console.WriteLine($"   Hệ: {item.TenHe} | Môn: {item.MaMon} - {item.TenMon}");

            // e. Lấy 5 môn học đầu tiên có số tiết giảm dần; hiển thị Tên hệ, Mã môn, Tên môn, Số tiết
            var cauE = (from h in dsHe
                        join m in dsMon on h.MaHe equals m.He
                        orderby m.SoTiet descending
                        select new { h.TenHe, m.MaMon, m.TenMon, m.SoTiet }).Take(5);
            Console.WriteLine("e. 5 môn học đầu tiên có số tiết giảm dần:");
            foreach (var item in cauE) Console.WriteLine($"   {item.TenHe} - {item.MaMon} - {item.TenMon} - {item.SoTiet}");

            // f. Cho biết tổng số môn học của mỗi hệ: Mã hệ, Tên hệ, Tổng số môn
            var cauF = from h in dsHe
                       join m in dsMon on h.MaHe equals m.He into g
                       select new { h.MaHe, h.TenHe, TongSoMon = g.Count() };
            Console.WriteLine("f. Tổng số môn học của mỗi hệ:");
            foreach (var item in cauF) Console.WriteLine($"   {item.MaHe} - {item.TenHe}: {item.TongSoMon} môn");

            // g. Cho biết có bao nhiêu loại Số tiết khác nhau trong danh sách môn học
            Console.WriteLine($"g. Số loại Số tiết khác nhau: {dsMon.Select(m => m.SoTiet).Distinct().Count()}");

            // h. Tìm môn học đầu tiên có tên bắt đầu bằng "Lập trình"
            var cauH = dsMon.FirstOrDefault(m => m.TenMon.StartsWith("Lập trình"));
            Console.WriteLine("h. Môn học đầu tiên bắt đầu bằng 'Lập trình':");
            if (cauH != null) Console.WriteLine($"   {cauH.MaMon} - {cauH.TenMon}");

            // i. Liệt kê các môn theo từng hệ, đánh số thứ tự trong mỗi nhóm
            Console.WriteLine("i. Liệt kê các môn theo từng hệ, đánh số thứ tự:");
            var cauI = dsMon.GroupBy(m => m.He);
            foreach (var group in cauI)
            {
                Console.WriteLine($"   Hệ {group.Key}:");
                var danhSach = group.Select((m, index) => new { STT = index + 1, m.MaMon, m.TenMon });
                foreach (var item in danhSach)
                {
                    Console.WriteLine($"      {item.STT}. {item.MaMon} - {item.TenMon}");
                }
            }
        }
    }
}