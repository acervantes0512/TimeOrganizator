export interface LoginResponse{
    id: number;
    nombreUsuario: string;
    fechaCreacion: Date;
    primerNombre: string;
    segundoNombre: string;
    primerApellido: string;
    segundoApellido: string;
    alias: string;
    fechaNacimiento: Date;
    token: string;
}