using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaProducto
{
    class Ventas
    {
		private string _Producto;
        private int _Cantidad;
        
		public string Producto
		{
			get { return _Producto; }
			set { _Producto = value; }
		}

		public int Cantidad
		{
			get { return _Cantidad; }
			set { _Cantidad = value; }
		}
		//Asignacion de precios a productos
		public double AsignarPrecio()
		{
			switch (Producto)
			{
				case "Teclado": return 35.00d;
				case "Mouse": return 20.00d;
				case "Monitor": return 550.00d;
				case "Impresora": return 350.00d;
				case "Bocinas": return 50.00d;
            }
			return 0.0;
		}
		// Calcular subtotal
		public double CalcularSubtotal()
		{
			return AsignarPrecio() * Cantidad;
		}
		// Calcular Descuento
		public double CalcularDescuento()
		{
			double Subtotal = CalcularSubtotal();
			switch (Subtotal)
			{
				case <= 300.0:
					return Subtotal * 0.05;
				case > 301.00 and <= 500.00:
                    return Subtotal * 0.10;
                case > 501.00:
                    return Subtotal * 0.125;
				default: return Subtotal;
            };
		}
        // Calcular Neto
        public double CalcularNeto()
		{
			return CalcularSubtotal() - CalcularDescuento();
		}
	}
}
