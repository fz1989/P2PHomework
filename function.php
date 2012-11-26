<?php
$con = mysql_connect("localhost","root","fz1989");
mysql_select_db("p2p", $con);
function doRegist()
{
	$username = isset($_REQUEST["username"]) ? $_REQUEST["username"] : "";
	$password = isset($_REQUEST["password"]) ? $_REQUEST["password"] : "";
	$password = $password . "nimeide"; 
	$password = md5($password, FALSE);
	if ($username == "" || $password == "") {
		return "NULL";
	}
	$sql = "select username from userinfo where username = '$username'";
	$result = mysql_query($sql);
	if (mysql_fetch_array($result)) {
		return "EXISI";
	}
	$sql = "insert into userinfo (username, password) values ('$username', '$password')";
	if (!mysql_query($sql))
	{
		return die('Error: ' . mysql_error());
	}
	return "SUCCESS";
}

function doLogin() 
{
	echo "Login";
}

function doShareFile()
{
	echo "ShareFile";
}

function doCancleShareFile()
{
	echo "CancleShareFile";
}

function doDownload()
{
	echo "Download";
}

function doUpload()
{
	echo "Upload";
}

function doLogoff()
{
	echo "Logoff";
}
?>