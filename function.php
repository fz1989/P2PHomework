<?php
header('Content-Type: text/html; charset=utf-8');
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

function checkFileExist($filename) 
{
	$sql = "select count(*) from fileinfo where filename = '$filename'";
	$result = mysql_query($sql);
	if (!$result) {
		return die('Error: ' . mysql_error());
	}
	$count = mysql_fetch_array($result);
	return $count[0];
}

function doShareFile()
{
	if (doLogin() != "SUCCESS") {
		return "ERROR";
	}
	if (checkFileExist($filename) != 0) {
		return "EXIST";
	} else {
		$sql = "insert into fileinfo (filename, filesize, filecount) values ('$filename', '$filesize', 1)";
		if (!mysql_query(sql)) {
			return die('Error: ' . mysql_error());
		}
		$sql = "insert into userfile (username, filename) values ('$username','$filename')";
		if (!mysql_query(sql)) {
			return die('Error: ' . mysql_error());
		}
	}
	return "SUCCESS";
}

function doCancleShareFile()
{
	if (doLogin() != "SUCCESS") {
		return "ERROR";
	}
	if (checkFileExist($filename) == 0) {
		return "NOTEXIST";
	} else {
		if ($count[0] == 1) {
			$sql = "delete from fileinfo where filename = '$filename'";
			if (!mysql_query(sql)) {
				return die('Error: ' . mysql_error());
			}
		} else {
			$sql = "update fileinfo set filecount = fliecount - 1 where filename = '$filename'";
			if (!mysql_query(sql)) {
				return die('Error: ' . mysql_error());
			}
			$sql = "delete from userfile where filename = '$filename' and username = '$username'";
			if (!mysql_query(sql)) {
				return die('Error: ' . mysql_error());
			}
		}
	}
	return "SUCCESS";
}

function doDownload()
{
	if (doLogin() != "SUCCESS") {
		return "ERROR";
	}
	if (checkFileExist($filename) == 0) {
		return "NOTEXIST";
	} else {
		$sql = "select userinfo.ipaddress, userinfo.port, fileinfo.filename 
				from fileinfo join userfile on userinfo.username = userfile.username 
				where fileinfo.filename = '$filename'";
		$result = mysql_query($sql);
		if (!$result) {
			return die('Error: ' . mysql_error());
		}
		array $ret;
		while ($row = mysql_fetch_array($result)) {
			$ret[] = $row;
		}
		return $ret;
	}
}

function doLogoff()
{
	if (doLogin() != "SUCCESS") {
		return "ERROR";
	}
	$sql = "update userinfo set online = 0 where username = '$username'";
	if (!mysql_query($sql)) {
		return die('Error: ' . mysql_error());
	}
	return "SUCCESS";
}

function doSearch() 
{
	if (doLogin() != "SUCCESS") {
		return "ERROR";
	}
	if (checkFileExist($filename) == 0) {
		return "NOTEXIST";
	} else {
		$sql = "select userinfo.username 
				from fileinfo join userfile on userinfo.username = userfile.username 
				where fileinfo.filename = '$filename'";
		$result = mysql_query($sql);
		if (!$result) {
			return die('Error: ' . mysql_error());
		}
		array $ret;
		while ($row = mysql_fetch_array($result)) {
			$ret[] = $row;
		}
		return $ret;
	}
}
?>