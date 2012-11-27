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
		echo json_encode(doSharefile());
	}
	else if ($action == "canclesharefile") {
		echo json_encode(doCanclesharefile());
	}
	else if ($action == "download") {
		echo json_encode(doDownload());
	} 
	else if ($action == "upload") {
		echo json_encode(doUpload());
	}
	else if ($action == "logoff") {
		echo json_encode(doLogoff());
	}
}
?>
