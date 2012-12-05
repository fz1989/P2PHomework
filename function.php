<?php
header('Content-Type: text/html; charset=utf-8');
require_once("getInit.php");
function checkLogin($username, $password) 
{
	$password	=	$password . "nimeide"; 
	$password	=	md5($password, FALSE);
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
		return "SUCCESS";
	}
}

function doRegist()
{
	$username	=	isset($_REQUEST["username"]) ? $_REQUEST["username"] : "";
	$password	=	isset($_REQUEST["password"]) ? $_REQUEST["password"] : "";
	$password	=	$password . "nimeide"; 
	$password	=	md5($password, FALSE);
	if ($username == "" || $password == "") {
		return "NULL";
	}
	$sql = "select username from userinfo where username = '$username'";
	$result = mysql_query($sql);
	if (!$result) {
		return die('Error: ' . mysql_error());
	}
	if ($row = mysql_fetch_array($result)) {
		return "EXIST";
	}
	$sql = "insert into userinfo (username, password) values ('$username', '$password')";
	if (!mysql_query($sql)) {
		return die('Error: ' . mysql_error());
	}
	return "SUCCESS";
}

function doLogin() 
{
	$username	=	isset($_REQUEST["username"]) ? $_REQUEST["username"] : "";
	$password	=	isset($_REQUEST["password"]) ? $_REQUEST["password"] : "";
	$port		= 	isset($_REQUEST["port"]) ? $_REQUEST["port"] : "";
	$ipaddress	=	isset($_REQUEST["ipaddress"]) ? $_REQUEST["ipaddress"] : "";
	$password	=	$password . "nimeide"; 
	$password	=	md5($password, FALSE);
	$ret = "SUCCESS";
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
		return $ret;
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

function checkFileUserExist($filename, $username) 
{
	$sql = "select count(*) from userfile where filename = '$filename' and username = '$username'";
	$result = mysql_query($sql);
	if (!$result) {
		return die('Error: ' . mysql_error());
	}
	$count = mysql_fetch_array($result);
	return $count[0];
}

function doShareFile()
{
	$username	=	isset($_REQUEST["username"]) ? $_REQUEST["username"] : "";
	$password	=	isset($_REQUEST["password"]) ? $_REQUEST["password"] : "";
	$filename	=	isset($_REQUEST["filename"]) ? $_REQUEST["filename"] : "";
	$filesize	=	isset($_REQUEST["filesize"]) ? $_REQUEST["filesize"] : "";
	$filepath	=	isset($_REQUEST["filepath"]) ? $_REQUEST["filepath"] : "";
	if (checkLogin($username, $password) != "SUCCESS") {
		return "ERROR";
	}
	if (checkFileExist($filename) != 0) {
		if (checkFileUserExist($filename, $username) == 0) {
			$sql = "update fileinfo set filecount = filecount + 1 where filename = '$filename'";
			$result = mysql_query($sql);
			$sql = "insert into userfile (username, filename, filepath) values ('$username', '$filename', '$filepath')";
			if (!mysql_query($sql)) {
				return die('Error: doShareFile' . mysql_error());
			}
			if (!$result) {
				return die('Error: doShareFile' . mysql_error());
			}
			return "SUCCESS";
		}
		else	return "EXIST";
	} else {
		$sql = "insert into fileinfo (filename, filesize, filecount) values ('$filename', '$filesize', 1)";
		if (!mysql_query($sql)) {
			return die('Error: doShareFile' . mysql_error());
		}
		$sql = "insert into userfile (username, filename, filepath) values ('$username', '$filename', '$filepath')";
		if (!mysql_query($sql)) {
			return die('Error: doShareFile' . mysql_error());
		}
	}
	return "SUCCESS";
}

function doCancleShareFile()
{
	$username	=	isset($_REQUEST["username"]) ? $_REQUEST["username"] : "";
	$password	=	isset($_REQUEST["password"]) ? $_REQUEST["password"] : "";
	$filename	=	isset($_REQUEST["filename"]) ? $_REQUEST["filename"] : "";
	if (checkLogin($username, $password) != "SUCCESS") {
		return "ERROR";
	}
	if (checkFileExist($filename) == 0) {
		return "FILENOTEXIST";
	} else {
		if (checkFileExist($filename) <= 1) {
			$sql = "delete from fileinfo where filename = '$filename'";
			if (!mysql_query($sql)) {
				return die('Error: ' . mysql_error());
			}
		} else {
			if (checkFileUserExist($filename, $username) == 0) return "NOTEXIST";
			$sql = "update fileinfo set filecount = filecount - 1 where filename = '$filename'";
			if (!mysql_query($sql)) {
				return die('Error: ' . mysql_error());
			}
			$sql = "delete from userfile where filename = '$filename' and username = '$username'";
			if (!mysql_query($sql)) {
				return die('Error: ' . mysql_error());
			}
		}
	}
	return "SUCCESS";
}
function doUpload() 
{
	$username	=	isset($_REQUEST["username"]) ? $_REQUEST["username"] : "";
	$password	=	isset($_REQUEST["password"]) ? $_REQUEST["password"] : "";
	if (checkLogin($username, $password) != "SUCCESS") {
		return "ERROR";
	} else {
		$ret = "";
		$sql = "select filename from userfile where username = '$username'";
		$result = mysql_query($sql);
		if (!$result) {
			return die('Error: ' . mysql_error());
		}
		while ($row = mysql_fetch_array($result)) {
			$ret = $ret . "" . $row["filename"] . "#";
		}
		return $ret;
	}
}
function doDownload()
{
	$requireuser	=	isset($_REQUEST["requireuser"]) ? $_REQUEST["requireuser"] : ""; 
	$username		=	isset($_REQUEST["username"]) ? $_REQUEST["username"] : "";
	$password		=	isset($_REQUEST["password"]) ? $_REQUEST["password"] : "";
	$filename		=	isset($_REQUEST["filename"]) ? $_REQUEST["filename"] : "";
	if (checkLogin($username, $password) != "SUCCESS") {
		return "ERROR";
	}
	if (checkFileExist($filename) == 0) {
		return "NOTEXIST";
	} else {
		$sql = "select userinfo.ipaddress, userinfo.port, userfile.filename, userfile.filepath
				from userinfo join userfile on userinfo.username = userfile.username
				where userfile.filename = '$filename'
				and userinfo.username = '$requireuser'";
		$result = mysql_query($sql);
		if (!$result) {
			return die('Error: ' . mysql_error());
		}
		$ret = "";
		while ($row = mysql_fetch_array($result)) {
			$ret = $ret . "" . $row["ipaddress"] . "&";
			$ret = $ret . "" . $row["port"]. "&";
			$ret = $ret . "" . $row["filename"]. "&";
			$ret = $ret . "" .	$row["filepath"];
		}
		return $ret;
	}
}

function doLogoff()
{
	$username	=	isset($_REQUEST["username"]) ? $_REQUEST["username"] : "";
	$password	=	isset($_REQUEST["password"]) ? $_REQUEST["password"] : "";
	if (checkLogin($username, $password) != "SUCCESS") {
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
	$username	=	isset($_REQUEST["username"]) ? $_REQUEST["username"] : "";
	$password	=	isset($_REQUEST["password"]) ? $_REQUEST["password"] : "";
	$filename	=	isset($_REQUEST["filename"]) ? $_REQUEST["filename"] : "";
	if (checkLogin($username, $password) != "SUCCESS") {
		return "ERROR";
	}
	if ($filename != "" && checkFileExist($filename) == 0) {
		return "NOTEXIST";
	} else {
		$sql = "select userfile.filename, fileinfo.filesize, userinfo.username, userinfo.online
				from (userinfo join userfile on userinfo.username = userfile.username) 
				join fileinfo on fileinfo.filename = userfile.filename 
				where userfile.filename = '$filename' 
				and userinfo.username <> '$username'";
		$result = mysql_query($sql);
		if (!$result) {
			return die('Error: ' . mysql_error());
		}
		$ret = "";
		while ($row = mysql_fetch_array($result)) {
			$ret= $ret . "" . $row[0] . "&";
			$ret= $ret . "" . $row[1] . "&";
			$ret= $ret . "" . $row[2] . "&";
			$ret= $ret . "" . $row[3] . "#";
		}
		return $ret;
	}
}
?>