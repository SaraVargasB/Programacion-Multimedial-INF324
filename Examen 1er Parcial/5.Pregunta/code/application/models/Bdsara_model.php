<?php
defined('BASEPATH') OR exit('No direct script access allowed');

class Bdsara_model extends CI_Model {

	public function __construct()
	{
		parent::__construct();
		$this->load->helper('url');
		//$this->load->database();
	}
	public function cuentas()
	{		
		$this->load->database();
		$query=$this->db->query("select * from cuenta");
		return $query->result();
	}
	public function cuentas1($id)
	{		
		$this->load->database();
		$query=$this->db->query("select * from cuenta where id='$id'");
		return $query->result();
	}
	 
	public function borrarCuenta($id)
	{
    $this->load->database();
    
    // Eliminar las transacciones asociadas a la cuenta
    $this->db->where('cuenta_origen_id', $id);
    $this->db->delete('transaccion');

    // Eliminar la cuenta
    $this->db->where('id', $id);
    $this->db->delete('cuenta');

    // Obtener los registros restantes
    $query = $this->db->get('cuenta');
    return $query->result();
	}

}



