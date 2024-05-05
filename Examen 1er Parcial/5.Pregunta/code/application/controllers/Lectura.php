<?php
defined('BASEPATH') OR exit('No direct script access allowed');

class Lectura extends CI_Controller {

	public function index()
	{
		$this->load->helper('url');
		$datos["Nombre"]="Sara";
		$datos["Apellido"]="Vargas";
//		$this->load->model("Bdsara_model");
		$this->load->model("Bdsara_model");
		$filas=$this->Bdsara_model->cuentas();
		$datos["filas"]=$filas;
		$this->load->view('view_lectura',$datos);

	}
	public function index2()
	{
		$datos["Nombre"]="Sara";
		$datos["Apellido"]="Vargas";
//		$this->load->model("Bdsara_model");
		$this->load->model("Bdsara_model");
		$filas=$this->Bdsara_model->cuentas1('1');
		$datos["filas"]=$filas;
		$this->load->view('view_lectura',$datos);

	}
    public function borrar($id)
	{
    $this->load->model("Bdsara_model");
    $datos["Nombre"] = "Sara";
    $datos["Apellido"] = "Vargas";
    $datos["filas"] = $this->Bdsara_model->borrarCuenta($id);
    $this->load->view('view_lectura', $datos);
	}
}

