                    $s = file_get_contents('http://ulogin.ru/token.php?token=' . $_POST['token'] . '&host=' . $_SERVER['HTTP_HOST']);
                    $user = json_decode($s, true);
                    //$user['network'] - ���. ����, ����� ������� ������������� ������������
                    //$user['identity'] - ���������� ������ ������������ ����������� ������������ ���. ����
                    //$user['first_name'] - ��� ������������
                    //$user['last_name'] - ������� ������������
                