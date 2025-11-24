import { Injectable } from '@angular/core';
import { RestService } from '@abp/ng.core';
import { Observable } from 'rxjs';

export interface ProductoDto {
  id: string;
  nombre: string;
  descripcion: string;
  precio: number;
  stock: number;
  categoriaId: string;
  imagenUrl: string;
  activo: boolean;
}

@Injectable({ providedIn: 'root' })
export class ProductoService {
  apiName = 'Default';

  constructor(private restService: RestService) {}

  obtenerLista(): Observable<ProductoDto[]> {
    return this.restService.request<void, ProductoDto[]>({
      method: 'GET',
      url: '/api/app/producto'
    });
  }

  obtenerPorId(id: string): Observable<ProductoDto> {
    return this.restService.request<void, ProductoDto>({
      method: 'GET',
      url: `/api/app/producto/${id}`
    });
  }

  crear(producto: Partial<ProductoDto>): Observable<ProductoDto> {
    return this.restService.request<Partial<ProductoDto>, ProductoDto>({
      method: 'POST',
      url: '/api/app/producto',
      body: producto
    });
  }

  actualizar(id: string, producto: Partial<ProductoDto>): Observable<ProductoDto> {
    return this.restService.request<Partial<ProductoDto>, ProductoDto>({
      method: 'PUT',
      url: `/api/app/producto/${id}`,
      body: producto
    });
  }

  eliminar(id: string): Observable<void> {
    return this.restService.request<void, void>({
      method: 'DELETE',
      url: `/api/app/producto/${id}`
    });
  }
}
