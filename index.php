<?php
header('Content-Type: text/html; charset=utf-8');
require_once("function.php");
if (!isset($_REQUEST["action"])) {
	echo "Error";
} else {
	$action = $_REQUEST["action"];
	if ($action == "regist") {
		echo doRegist();
	} 
	else if ($action == "login") {
		echo doLogin();
	}
	else if ($action == "upload") {
		echo doUpload();
	}
	else if ($action == "sharefile") {
		echo doSharefile();
	}
	else if ($action == "canclesharefile") {
		echo doCanclesharefile();
	}
	else if ($action == "download") {
		echo doDownload();
	} 
	else if ($action == "logoff") {
		echo doLogoff();
	} 
	else if ($action == "search") {
		echo doSearch();
	}
	else echo "Error Action";
}
?>
