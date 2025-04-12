
using System.Diagnostics.Contracts;
class Karyawan
{
    private string nama;
    private string id;
    private double gajiPokok;
    public Karyawan(string nama, string id, double gajiPokok)
    {
        this.nama = nama;
        this.id = id;
        this.gajiPokok = gajiPokok;
    }
    public string Nama
    {
        get { return nama; }
        set { nama = value; }
    } 
    public string ID
    {
        get { return id; }
        set { id = value; }
    }
    public double GajiPokok
    {
        get { return gajiPokok; }
        set { gajiPokok = value; }
    }

    public virtual double HitungGaji()
    {
        return gajiPokok;
    }
}

class KaryawanTetap : Karyawan
{
    public KaryawanTetap(string nama, string id, double gajiPokok)
        : base(nama, id, gajiPokok) { }

    public override double HitungGaji()
    {
        return GajiPokok + 500000; //bonus tetap
    }
}

class KaryawanKontrak : Karyawan
{
    public KaryawanKontrak(string nama, string id, double gajiPokok)
        : base(nama, id, gajiPokok) { }

    public override double HitungGaji()
    {
        return GajiPokok - 200000; //potongan kontrak
    }
}

class KaryawanMagang : Karyawan
{
    public KaryawanMagang(string nama, string id, double gajiPokok)
        : base(nama, id, gajiPokok) { }

    public override double HitungGaji()
    {
        return GajiPokok; //tidak ada potongan maupun bonus
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Input Data Karyawan");
        Console.Write("Jenis Karyawan (Tetap/Kontrak/Magang): ");
        string jenis = Console.ReadLine().ToLower();

        Console.Write("Nama: ");
        string nama = Console.ReadLine();

        Console.Write("ID: ");
        string id = Console.ReadLine();

        Console.Write("Gaji Pokok: ");
        double gajiPokok = Convert.ToDouble(Console.ReadLine());

        Karyawan karyawan;
        if (jenis == "tetap")
        {
            karyawan = new KaryawanTetap(nama, id, gajiPokok);
        }
        else if (jenis == "kontrak")
        {
            karyawan = new KaryawanKontrak(nama, id, gajiPokok);
        }
        else if (jenis == "magang")
        {
            karyawan = new KaryawanMagang(nama, id, gajiPokok);
        }
        else
        {
            Console.WriteLine("Jenis karyawan tidak vallid.");
            return;
        }

        Console.WriteLine("\nInformasi Gaji");
        Console.WriteLine("Nama: " + karyawan.Nama);
        Console.WriteLine("ID: " + karyawan.ID);
        Console.WriteLine("Gaji Akhir: " + karyawan.HitungGaji());
    }
}
