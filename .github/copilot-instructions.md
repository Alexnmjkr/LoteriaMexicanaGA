# Copilot Instructions

## General Guidelines
- First general instruction
- Second general instruction

## Code Style
- Use specific formatting rules
- Follow naming conventions

## Error Handling
- Cuando corrija errores en formularios, eliminar declaraciones duplicadas/incorrectas de controles definidos por el diseñador (ej. `private object timerAuto;`, `lblEstadoRed`) en la clase parcial; corregir errores de sintaxis como `if i > 0)` a `if (i > 0)`. Asegurar que el constructor sin parámetros invoque `InitializeComponent()` para inicializar controles del diseñador. No reemplazar controles del diseñador por variables de tipo `object`. Mantener los miembros declarados en el `.Designer.cs`.