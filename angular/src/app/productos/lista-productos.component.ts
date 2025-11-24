import { Component, OnInit } from '@angular/core';
import { ProductoService, ProductoDto } from './services/producto.service';

@Component({
  selector: 'app-lista-productos',
  template: `
    <div class="container mt-4">
      <h2>Catálogo de Productos</h2>
      <div class="row mt-4">
        <div class="col-md-3" *ngFor="let producto of productos">
          <div class="card mb-4">
            <img [src]="producto.imagenUrl || 'assets/no-image.png'" class="card-img-top" alt="{{ producto.nombre }}">
            <div class="card-body">
              <h5 class="card-title">{{ producto.nombre }}</h5>
              <p class="card-text">{{ producto.descripcion }}</p>
              <p class="text-primary fw-bold">\${{ producto.precio }}</p>
              <button class="btn btn-primary btn-sm" (click)="agregarAlCarrito(producto)">
                Agregar al Carrito
              </button>
            </div>
          </div>
        </div>
      </div>
    </div>
  `
})
export class ListaProductosComponent implements OnInit {
  productos: ProductoDto[] = [];

  constructor(private productoService: ProductoService) {}

  ngOnInit() {
    this.cargarProductos();
  }

  cargarProductos() {
    this.productoService.obtenerLista().subscribe(
      productos => this.productos = productos
    );
  }

  agregarAlCarrito(producto: ProductoDto) {
    // Lógica para agregar al carrito
    console.log('Agregado al carrito:', producto);
  }
}
