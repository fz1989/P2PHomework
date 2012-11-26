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
	if (!$result) {
		return die('Error: ' . mysql_error());
	}
	if ($row = mysql_fetch_array($result)) {
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
	$username = isset($_REQUEST["username"]) ? $_REQUEST["username"] : "";
	$password = isset($_REQUEST["password"]) ? $_REQUEST["password"] : "";
	$port = isset($_REQUEST["port"]) ? $_REQUEST["port"] : "";
	$ipaddress = isset($_REQUEST["ipaddress"]) ? $_REQUEST["ipaddress"] : "";
	$password = $password . "nimeide"; 
	$password = md5($password, FALSE);
	if ($username == "" || $password == "") {
		return "NULL";
	}
	$sql = "select password from userinfo where username = '$username'";
	$result = mysql_query($sql);
	if (!$result) {
		return die('Error: ' . mysql_error());
	}
	if (!($row = mysql_fetch_array($result))) {
		return "NOTEXIST";
	} else {
		if ($password != $row["password"]) {
			return "WRONG";
		}
		$sql = "update userinfo set online = 1, 
									port = '$port', 
									ipaddress = '$ipaddress' 
				where username = '$username'";
		if (!mysql_query($sql))
		{
			return die('Error: ' . mysql_error());
		}
		return "SUCCESS";
	}
}

function doShareFile()
{
	$username = isset($_REQUEST["username"]) ? $_REQUEST["username"] : "";
	$filename = isset($_REQUEST["filename"]) ? $_REQUEST["filename"] : "";
	$filesize = isset($_REQUEST["filesize"]) ? $_REQUEST["filesize"] : "";
	echo "ShareFile";
}

function doCancleShareFile()
{
	$username = isset($_REQUEST["username"]) ? $_REQUEST["username"] : "";
	$filename = isset($_REQUEST["filename"]) ? $_REQUEST["filename"] : "";
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
	$username = isset($_REQUEST["username"]) ? $_REQUEST["username"] : "";
	$sql = "update userinfo set online = 0 where username = '$username'";
	if (!mysql_query($sql))
	{
		return die('Error: ' . mysql_error());
	}
	return "SUCCESS";
}
?>