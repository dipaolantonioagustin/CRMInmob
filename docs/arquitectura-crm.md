# Arquitectura propuesta - CRM Inmobiliario

## Objetivo
Implementar un CRM web para administración y ventas inmobiliarias que permita registrar, asignar y dar seguimiento a tareas operativas/comerciales.

## Stack solicitado
- **Backend:** ASP.NET Core (C#)
- **Base de datos:** SQL Server
- **Frontend:** Web con Bootstrap 5

## Módulos funcionales (MVP)
1. **Gestión de tareas**
   - Alta/edición de tareas
   - Prioridades (Baja, Media, Alta, Crítica)
   - Estados (Pendiente, En progreso, Esperando cliente, Completada, Cancelada)
   - Vencimiento y alertas por fecha
2. **Asignación de usuarios**
   - Cada tarea tiene usuario responsable
   - Creación de tarea por administrador/supervisor
3. **Panel diario por usuario**
   - Listado ordenado por prioridad y vencimiento
   - Cambio rápido de estado
4. **Referencias de negocio**
   - Contacto asociado (inquilino/comprador/inversor)
   - Carpeta inmobiliaria asociada (alquiler, venta, proyecto)
5. **Control de permisos**
   - Rol Administrador: asigna, reasigna y prioriza
   - Rol Ejecutivo: gestiona tareas asignadas

## Flujos de trabajo contemplados
- Reparaciones de alquileres
- Renovaciones de alquiler con negociación
- Seguimiento de leads por proyectos en promoción
- Seguimiento de ofertas de compra/venta
- Contratos listos para firma/pago

## Próximos pasos recomendados
1. Incorporar autenticación JWT o cookie auth según canal de consumo.
2. Agregar notificaciones (email/WhatsApp interno) para tareas críticas y vencidas.
3. Implementar auditoría de cambios de estado y comentarios por tarea.
4. Construir tablero Kanban por equipo (operaciones/ventas).
