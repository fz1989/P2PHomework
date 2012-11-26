<?php
header('Content-Type: text/html; charset=utf-8');
require_once("function.php");
if (!isset($_REQUEST["action"])) {
	echo json_encode("Error");
} else {
	$action = $_REQUEST["action"];
	echo $action;
	if ($action == "regist") {
		echo json_encode(doRegist());
	} 
	else if ($action == "login") {
		echo json_encode(doLogin());
	}
	else if ($action == "sharefile") {
		doSharefile();
	}
	else if ($action == "canclesharefile") {
		doCanclesharefile();
	}
	else if ($action == "download") {
		doDownload();
	} 
	else if ($action == "upload") {
		doUpload();
	}
	else if ($action == "logoff") {
		doLogoff();
	}
}
?>
