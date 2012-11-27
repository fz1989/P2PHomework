<?php
$con = mysql_connect("localhost","root","fz1989");
mysql_select_db("p2p", $con);
$username	=	isset($_REQUEST["username"]) ? $_REQUEST["username"] : "";
$password	=	isset($_REQUEST["password"]) ? $_REQUEST["password"] : "";
$port		= 	isset($_REQUEST["port"]) ? $_REQUEST["port"] : "";
$ipaddress	=	isset($_REQUEST["ipaddress"]) ? $_REQUEST["ipaddress"] : "";
$filename	=	isset($_REQUEST["filename"]) ? $_REQUEST["filename"] : "";
$filesize	=	isset($_REQUEST["filesize"]) ? $_REQUEST["filesize"] : "";
$password	=	$password . "nimeide"; 
$password	=	md5($password, FALSE);
?>