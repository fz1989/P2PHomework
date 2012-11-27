<?php
require_once("getInit.php");
function doRegist()
{
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
	if (!mysql_query($sql)) {
		return die('Error: ' . mysql_error());
	}
	return "SUCCESS";
}

function doLogin() 
{
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
		$sql = "update userinfo set online = 1, port = '$port', ipaddress = '$ipaddress' 
				where username = '$username'";
		if (!mysql_query($sql)) {
			return die('Error: ' . mysql_error());
		}
		return "SUCCESS";
	}
}

function doShareFile()
{
	if (doLogin() != "SUCCESS") {
		return "ERROR";
	}
	return "SUCCESS";
}

function doCancleShareFile()
{
	if (doLogin() != "SUCCESS") {
		return "ERROR";
	}
	return "SUCCESS";
}

function doDownload()
{
	if (doLogin() != "SUCCESS") {
		return "ERROR";
	}
	return "SUCCESS";
}

function doUpload()
{
	if (doLogin() != "SUCCESS") {
		return "ERROR";
	}
	return "SUCCESS";
}

function doLogoff()
{
	if (doLogin() != "SUCCESS") {
		return "ERROR";
	}
	$sql = "update userinfo set online = 0 where username = '$username'";
	if (!mysql_query($sql))
	{
		return die('Error: ' . mysql_error());
	}
	return "SUCCESS";
}
?>